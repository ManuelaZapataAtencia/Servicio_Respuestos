using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Servicios_PD.Clases;
using Servicio_Respuestos.Clases;

namespace Servicio_Respuestos.Clases
{
    public class clsUsuario
    {
        private DBTallerMotosEntities dbTallerMotos = new DBTallerMotosEntities();
        public usuario usuario { get; set; }
        public usuario ValidarUsuario(LoginCliente login)
        {
            clsCypher cifrar = new clsCypher();
            cifrar.Password = login.Clave;
            usuario _usuario = dbTallerMotos.usuario.FirstOrDefault(
                    u => u.nombre_usuario == login.Usuario);
            if (_usuario == null) 
                return null;
            byte[] storageSaltBytes = Convert.FromBase64String(_usuario.salt);
            string passwordCifrado = cifrar.HashPassword(login.Clave, storageSaltBytes);
            return dbTallerMotos.usuario.FirstOrDefault(
                u => u.nombre_usuario == login.Usuario && u.clave == passwordCifrado);
        }
        public IQueryable<LoginRespuesta> ConsultarUsuario(LoginCliente login)
        {
            LoginRespuesta loginRespuesta = new LoginRespuesta();
            usuario _usuario = ValidarUsuario(login);
            if (ValidarUsuario(login) == null)
            {
                loginRespuesta.Error = "Usuario inexistente";
                return null;
            }
            else
            {
                //Si existe el usuario, se genera la consulta para retornar el usuario y se genera el token
                string tokenGenerado = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbTallerMotos.Set<usuario>()
                       join UP in dbTallerMotos.Set<usuario_perfil>()
                       on U.id equals UP.id_usuario
                       join P in dbTallerMotos.Set<perfil>()
                       on UP.id_perfil equals P.id
                       where U.nombre_usuario == login.Usuario &&
                             U.clave == _usuario.clave
                       select new LoginRespuesta
                       {
                           Token = tokenGenerado,
                           Perfil = P.Nombre,
                           PaginaNavegar = P.pagina_navegar,
                           Autenticado = true
                       };
            }
        }
        public string Actualizar(int idPerfil)
        {
            clsCypher Cifrar = new clsCypher();
            Cifrar.Password = usuario.clave;
            if (Cifrar.CifrarClave())
            {
                usuario _usuario = dbTallerMotos.usuario.FirstOrDefault(u => u.cedula_usuario == usuario.cedula_usuario);
                _usuario.nombre_usuario = usuario.nombre_usuario;
                _usuario.clave = Cifrar.PasswordCifrado;
                dbTallerMotos.usuario.AddOrUpdate(_usuario);
                dbTallerMotos.SaveChanges();
                usuario_perfil usuario_Perfil = dbTallerMotos.usuario_perfil.FirstOrDefault(p => p.id_usuario == _usuario.id && p.activo == true);
                usuario_Perfil.id_perfil = idPerfil;
                dbTallerMotos.usuario_perfil.AddOrUpdate(usuario_Perfil);
                dbTallerMotos.SaveChanges();
                return "Se actualizó el usuario: " + _usuario.nombre_usuario;
            }
            else
            {
                return "No se pudo actualizar la clave del usuario";
            }
        }
        public string ActivarUsuario(string Documento, bool Activo)
        {
            usuario _usuario = dbTallerMotos.usuario.FirstOrDefault(u => u.cedula_usuario == Documento);
            usuario_perfil usuario_Perfil = dbTallerMotos.usuario_perfil.FirstOrDefault(p => p.id_usuario == _usuario.id);
            usuario_Perfil.activo = Activo;
            dbTallerMotos.usuario_perfil.AddOrUpdate(usuario_Perfil);
            dbTallerMotos.SaveChanges();
            return "Se activó el usuario: " + _usuario.nombre_usuario;
        }
        public string Insertar(int idPerfil)
        {
            clsCypher Cifrar = new clsCypher();
            Cifrar.Password = usuario.clave;
            if (Cifrar.CifrarClave())
            {
                //Se hizo el cifrado de la clave
                usuario.clave = Cifrar.PasswordCifrado;
                usuario.salt = Cifrar.Salt;
                dbTallerMotos.usuario.Add(usuario);
                dbTallerMotos.SaveChanges();

                //Ya se tiene el usuario, se debe grabar el usuario perfil
                usuario_perfil usuario_Perfil = new usuario_perfil();
                usuario_Perfil.id_usuario = usuario.id;
                usuario_Perfil.id_perfil = idPerfil;
                usuario_Perfil.activo = true;
                dbTallerMotos.usuario_perfil.Add(usuario_Perfil);
                dbTallerMotos.SaveChanges();
                return "Se creó el usuario: " + usuario.nombre_usuario;
            }
            else
            {
                return "No se pudo almacenar la clave del usuario";
            }
        }
    }
}