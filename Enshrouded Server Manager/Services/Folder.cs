


namespace Enshrouded_Server_Manager.Services
{
    public class Folder
    {

        /// <summary>
        /// look if folder exists if not create
        /// </summary>
        public void create(String Foldername)
        {
            if (!Directory.Exists(Foldername))
            {
                Directory.CreateDirectory(Foldername);
            }

        }


    }

}
