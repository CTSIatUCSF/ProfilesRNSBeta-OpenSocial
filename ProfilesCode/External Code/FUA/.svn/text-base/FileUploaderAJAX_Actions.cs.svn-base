using System.Collections.Generic;
using System.IO;

namespace Subgurim.Controles
{
    public partial class FileUploaderAJAX
    {
        #region Acciones

        /// <summary>
        /// Save the file.
        /// Add to Historial
        /// </summary>
        /// <param name="path"></param>
        public void SaveAs(string path)
        {
            if (History == null)
                History = new List<HttpPostedFileAJAX>();

            // Cancelamos si un fichero ha sido ya guardado con el mismo nombre
            // o si ya existía, fue borrado
            int historialIndex = FindHistorialIndex(path);
            // Borramos del historial si realmente existia
            if (historialIndex >= 0)
                if (!History[historialIndex].Deleted) return;

            path = path.Replace('\\', '/');
            //string fileName = path.Substring(path.LastIndexOf('/') + 1);
            //string directory = path.Substring(0, path.LastIndexOf('/') + 1);
            string fileName = Path.GetFileName(path);
            string directory = path.Replace(fileName, "");

            if (Directory_CreateIfNotExists)
                if (!Directory.Exists(Server.MapPath(directory)))
                    Directory.CreateDirectory(Server.MapPath(directory));

            if (File_RenameIfAlreadyExists)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string _fileNameWithoutExtension = fileNameWithoutExtension;
                string extension = Path.GetExtension(fileName);

                int contador = 1;
                if (File.Exists(Server.MapPath(directory + _fileNameWithoutExtension + extension)))
                {
                    while (File.Exists(Server.MapPath(directory + _fileNameWithoutExtension + extension)))
                    {
                        _fileNameWithoutExtension = fileNameWithoutExtension + "_" + contador++;
                    }
                }

                fileName = _fileNameWithoutExtension + extension;
            }

            path = directory + fileName;


            using (Stream InputStream = Request.Files[0].InputStream)
            {
                lock (thisLock2)
                {
                    byte[] buffer = new byte[InputStream.Length];
                    InputStream.Read(buffer, 0, (int) InputStream.Length);

                    lock (thisLock)
                    {
                        File.WriteAllBytes(Server.MapPath(path), buffer);
                        buffer = null;
                    }
                    InputStream.Close();
                }
            }

            PostedFile.FileName_SavedAs = path;
            PostedFile.Saved = true;

            if (historialIndex >= 0)
                History[historialIndex] = PostedFile;
            else
                History.Add(PostedFile);
        }

        /// <summary>
        /// Save the file, where the path is the root + the original filename (~/originialfilename)
        /// Add to Historial.
        /// </summary>
        public void Save()
        {
            SaveAs("~/" + PostedFile.FileName);
        }

        /// <summary>
        /// Save the file.
        /// Add to Historial
        /// </summary>
        /// <param name="directoryPath">The directory to save to</param>
        /// <param name="FileName">The file name</param>
        public void SaveAs(string directoryPath, string FileName)
        {
            directoryPath = directoryPath.EndsWith("/") ? directoryPath : directoryPath + "/";

            SaveAs(directoryPath + FileName);
        }


        /// <summary>
        /// Delete the file.
        /// Delete from 'historial'.
        /// Returns the index in historial
        /// </summary>
        /// <param name="path"></param>
        private int Delete(string path)
        {
            string destino = Server.MapPath(path);
            if (File.Exists(destino))
            {
                lock (thisLock)
                {
                    File.Delete(destino);
                }

                // Buscamos un fichero en el historial con el mismo nombre
                int i = FindHistorialIndex(path);

                // Borramos del historial si realmente existia
                if (i >= 0)
                    History[i].Deleted = true;

                return i;
            }

            return -1;
        }

        private int FindHistorialIndex(string path)
        {
            return History.FindIndex(delegate(HttpPostedFileAJAX pf) { return pf.FileName_SavedAs.Equals(path); });
        }

        private bool AlreadySavedFile(string path)
        {
            return FindHistorialIndex(path) >= 0;
        }

        private int totalGuardadosEnHistorial()
        {
            if (null != History)
                return History.FindAll(delegate(HttpPostedFileAJAX fu) { return fu.Saved; }).Count;

            return 0;
        }

        #endregion
    }
}