using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using LumenWorks.Framework.IO.Csv;
using UnityEngine;

namespace Dress.Core
{

    public class FileLoader : Singleton<FileLoader>
    {
        public class DiaryData
        {
            public int category;
            public int dressCode;
        }

        public class DiaryDataCollection
        {
            private List<DiaryData> diaryDatas = new List<DiaryData>();

            public void AddData(DiaryData data)
            {
                diaryDatas.Add(data);
            }

            public List<DiaryData> GetDatas()
            {
                return diaryDatas;
            }
        }

        private List<DiaryDataCollection> diaryCollections = new List<DiaryDataCollection>();

        private FileLoader()
        {

        }

        public void LoadFiles()
        {
            LoadDiary();
        }


        public DiaryDataCollection GetDiaryCollection(int index)
        {
            if (index < diaryCollections.Count)
            {
                return diaryCollections[index];
            }

            return new DiaryDataCollection();
        }


        private void LoadDiary()
        {
            string filePath = Platform.Instance().GetPersistentDataPath("DiaryData.txt");
            //csv
            /*using (CsvReader csv = new CsvReader(new StreamReader(filePath), false))
            {
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < csv.FieldCount; i += 2)
                    {
                        if (csv[i] == null)
                        {
                            break;
                        }

                        int count = 0;
                        DiaryData data = new DiaryData();
                        data.category = Int32ParseFast(csv[i]);
                        data.dressCode = Int32ParseFast(csv[i + 1]);

                        diaryDatas.Add(data);    
                    }
                }
            }*/

            diaryCollections.Clear();

            if (File.Exists(filePath))
            {
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);

                string str = string.Empty;

                while ((str = reader.ReadLine()) != null)
                {
                    DiaryDataCollection collection = new DiaryDataCollection();

                    string[] res = str.Split(',');

                    for (int i = 0; i < res.Length; i += 2)
                    {
                        DiaryData data = new DiaryData();
                        data.category = Int32ParseFast(res[i]);
                        data.dressCode = Int32ParseFast(res[i + 1]);

                        collection.AddData(data);
                    }

                    diaryCollections.Add(collection);
                }

                reader.Close();
                file.Close();
            }
        }

        public static short Int16ParseFast(string value)
        {
            short result = 0;
            int length = value.Length;
            bool minus = false;
            for (int i = 0; i < length; i++)
            {
                if (value[i].CompareTo('-') == 0)
                {
                    minus = true;
                    continue;
                }
                result = (short) (10*result + (value[i] - 48));
            }
            return minus == false ? result : (short) (-result);
        }

        public static int Int32ParseFast(string value)
        {
            int result = 0;
            int length = value.Length;
            bool minus = false;
            for (int i = 0; i < length; i++)
            {
                if (value[i].CompareTo('-') == 0)
                {
                    minus = true;
                    continue;
                }
                result = 10*result + (value[i] - 48);
            }
            return minus == false ? result : -result;
        }
    }

}