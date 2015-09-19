using System.Collections.Generic;
using System.IO;

namespace Dress.Core
{
    public class FileWriter : Singleton<FileWriter>
    {
        private FileWriter()
        {
            
        }

        public void SaveDiaryDress(List<DressItem> dressItems)
        {
            string filePath = Platform.Instance().GetPersistentDataPath("DiaryData.txt");

            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);

            string str = ""; 
            foreach (DressItem dressItem in dressItems)
            {

                str += (int)dressItem.dressCategory + ",";
                str += dressItem.dressCode.ToString() + ",";
            }

            str = str.Substring(0, str.LastIndexOf(','));

            sw.WriteLine(str);
            sw.Close();
            file.Close();
        }
    }
}