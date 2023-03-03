using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Serl;

namespace DictionaryService
{
    internal class Dictionary : ISerialiazation
    {
        public Dictionary() { }

        public void CreateDictionary()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("ENTER FIRST LANGUAGE : ");
            FirstLanguageName = Console.ReadLine();

            Console.Write("ENTER SECOND LANGUAGE : ");
            SecondLanguageName = Console.ReadLine();
        }

        public void PrintDictionary()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("DICTIONARY ->\n");

            Console.WriteLine($"{FirstLanguageName.ToUpper()} -> {SecondLanguageName.ToUpper()}");

            for (int i = 0; i < translationPairs.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}");
                translationPairs[i].PrintPairs();
            }
        }
        public void remove()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int index = new();

            PrintDictionary();

            Console.Write("ENTER INDEX : ");

            index = Convert.ToInt32(Console.ReadLine());

            translationPairs.RemoveAt(index);
        }

        public void add()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            TranslationPair tmp = new();

            tmp = tmp.CreateTraslationPair();

            translationPairs.Add(tmp);
        }
        

        public void change()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            string tmp_copy;
            StringBuilder new_word;

            Console.Write("ENTER WORD'S INDEX : ");
            indx = Convert.ToInt32(Console.ReadLine());

            Console.Write("ENTER NEW WORD : ");
            tmp_copy = Console.ReadLine();

            new_word = new StringBuilder(tmp_copy);
            translationPairs[indx].LastLanguageTranslation.Append(new_word);
        }

        public void editDictionary()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice = new();

            Console.Clear();

            Console.WriteLine("EDITING MENU\n" +
                "1 - ADD WORD\n" +
                "2 - CHANGE WORD\n" +
                "3 - REMOWR WORD\n" +
                "4 - EXIT\n"
                );
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    add();
                    break;
                case 2:
                    change();
                    break;
                case 3:
                    remove();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        public void find()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StringBuilder tmp = new();
            string tmp_copy;
            bool key = true;
            int i = 0;

            Console.Write($"ENTER WORD ON {FirstLanguageName.ToUpper()} TO FIND ITS TRANSLATION~# ");
            tmp_copy = Console.ReadLine();

            tmp = new StringBuilder(tmp_copy);

            while (key)
            {
                if (translationPairs[i].FirstLanguageTranslation == tmp)
                {
                    translationPairs[i].PrintPairs();
                    key = false;
                }
                i++;
            }
        }

        public void save()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("dictionary_data.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public List<TranslationPair> translationPairs { get; set; }
        public string FirstLanguageName { get; set; }
        public string SecondLanguageName { get; set; }
    }

    class TranslationPair : ISerialiazation
    {
        public TranslationPair() { }

        public TranslationPair(StringBuilder firstLanguageTranslation, StringBuilder[] lastLanguageTranslation)
        {
            FirstLanguageTranslation = firstLanguageTranslation;
            LastLanguageTranslation = lastLanguageTranslation;
        }

        public StringBuilder[] CreateTranslation()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("TRANSLATIONS");
            Console.Write("ENTER AMMOUNT OF WORDS :");

            int number = Convert.ToInt32(Console.ReadLine());
            string tmp_copy;

            StringBuilder[] tmp = new StringBuilder[number];

            for (int i = 0; i < number; i++)
            {
                Console.Write("ENTER WORD : ");
                tmp_copy = Console.ReadLine();

                tmp[i] = new StringBuilder(tmp_copy);
            }

            return tmp;
        }

        public TranslationPair CreateTraslationPair()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string tmp_copy;

            Console.WriteLine("TRANSLATION PAIR\n");

            Console.Write("ENTER WORD : ");
            tmp_copy = Console.ReadLine();

            StringBuilder tmpFirstLanguage = new StringBuilder(tmp_copy);
            StringBuilder[] tmpLastLanguage = CreateTranslation();

            TranslationPair tmp = new TranslationPair(tmpFirstLanguage, tmpLastLanguage);

            return tmp;
        }

        public void PrintPairs()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ORIGIN LANGUAGE -> ");

            for (int i = 0; i < FirstLanguageTranslation.Length; i++)
            {
                Console.WriteLine(FirstLanguageTranslation[i] + " ");
            }

            Console.WriteLine("TRANSLATE LANGUAGE ->\n ");

            for (int i = 0; i < LastLanguageTranslation.Length; i++)
            {
                Console.WriteLine(LastLanguageTranslation[i] + " ");
            }
        }

        public void SaveWord()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("res_file.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public StringBuilder FirstLanguageTranslation { get => FirstLanguageTranslation; set => FirstLanguageTranslation = value; }
        public StringBuilder[] LastLanguageTranslation { get => LastLanguageTranslation; set => LastLanguageTranslation = value; }
    }
}
