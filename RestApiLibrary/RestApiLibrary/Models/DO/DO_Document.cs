using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    public class DO_Document 
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_Document(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }
        /// <summary>
        /// Devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        public List<Document> GetAll()
        {
            try
            {
                List<Document> list;

                list = dbLibrary.tc_Document.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve todos los registros por CategoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Document> GetCategoryId(int categoryId)
        {
            try
            {
                List<Document> list;

                list = dbLibrary.tc_Document.Where(a => a.CategoryId == categoryId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve todos los registros por AuthorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public List<Document> GetAuthorId(int authorId)
        {
            try
            {
                List<Document> list;

                list = dbLibrary.tc_Document.Where(a => a.AuthorId == authorId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve todos los registros por EditorialId
        /// </summary>
        /// <param name="editorialId"></param>
        /// <returns></returns>
        public List<Document> GetEditorialId(int editorialId)
        {
            try
            {
                List<Document> list;

                list = dbLibrary.tc_Document.Where(a => a.EditorialId == editorialId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve un registro por Id
        /// </summary>
        /// <param name="DocumentId"></param>
        /// <returns></returns>
        public Document GetId(int DocumentId)
        {
            try
            {
                Document row;

                row = dbLibrary.tc_Document.Where(a => a.DocumentId == DocumentId).FirstOrDefault();

                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Metodo para crear registro
        /// </summary>
        /// <param name="objnew"></param>
        /// <returns></returns>
        public Operations Create(Document objnew)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_Document.Add(objnew);
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Registro creado";
                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro crear el registro:-");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        regOperacion.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            regOperacion.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    operations.Result = "Error";
                    operations.Message = regOperacion.ToString();
                }

                return operations;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Metodo para actualizar registro
        /// </summary>
        /// <param name="objUpd"></param>
        /// <returns></returns>
        public Operations Update(Document objUpd)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    Document row;
                    row = dbLibrary.tc_Document.Where(a => a.DocumentId == objUpd.DocumentId).FirstOrDefault();
                    row.Title = objUpd.Title;
                    row.ImagenPath = objUpd.ImagenPath;
                    row.PdfPath = objUpd.PdfPath;
                    row.Private = objUpd.Private;
                    row.UserId = objUpd.UserId;
                    row.CategoryId = objUpd.CategoryId;
                    row.AuthorId = objUpd.AuthorId;
                    row.EditorialId = objUpd.EditorialId;
                    row.PublicationDate = objUpd.PublicationDate;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Registro actualizado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el registro");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        regOperacion.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            regOperacion.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    operations.Result = "Error";
                    operations.Message = regOperacion.ToString();
                }

                return operations;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Actualiza el estado del registro
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(int documentId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    Document row;
                    row = dbLibrary.tc_Document.Where(a => a.DocumentId == documentId).FirstOrDefault();
                    row.State = (state) ? 1 : 0;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Estado Modificado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el estado");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        regOperacion.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            regOperacion.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    operations.Result = "Error";
                    operations.Message = regOperacion.ToString();
                }

                return operations;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}