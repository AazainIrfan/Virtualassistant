using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {

                SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));


                Choices my_choices = new Choices();
                my_choices.Add("What's your name");
                my_choices.Add("What is your name");
                my_choices.Add("Who is your designer");
                my_choices.Add("Hello computer");
                my_choices.Add("Hello");
                my_choices.Add("Hi");
                my_choices.Add("Hi there");
                my_choices.Add("Hey computer Welcome to the world");
                my_choices.Add("Hello there");
                my_choices.Add("I am great, what about you");
                my_choices.Add("I am good");
                my_choices.Add("I am fine");
                my_choices.Add("Not good");
                my_choices.Add("I am not feeling good today");
                my_choices.Add("Open Visual studio");
                my_choices.Add("open calculator");
                my_choices.Add("open word");
                my_choices.Add("Open Notepad");
                my_choices.Add("open ecxel");
                my_choices.Add("open youtube");
                GrammarBuilder grammarBuilder = new GrammarBuilder(my_choices);
                Grammar grammar = new Grammar(grammarBuilder);
                recognizer.LoadGrammar(grammar);
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

            }
            Console.ReadKey();


        }

        public static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            SpeechSynthesizer my_assistant = new SpeechSynthesizer();

            switch (e.Result.Text)
            {
                case "What's your name":
                case "Hello computer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Hello Mr Aazain, it is a plwasure to meet you, How are you!");
                    break;
                case "What is your name":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("My name is Bixby");
                    break;
                case "Who is your designer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("My designer is Mr Aazain");
                    break;

                case "Huy computer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Hello Mr Aazain, it is a plwasure to meet you, How are you!");
                    break;
                case "Hello":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Huy There, How are you!");
                    break;
                case "Hi":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Huy There, How are you!");
                    break;
                case "Hi there":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Huy There, How are you!");
                    break;
                case "Hey computer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Huy There, How are you!");
                    break;
                case "Hello there":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Huy There, How are you!");
                    break;
                case "I am great, what about you":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "I am good":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "I am fine":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "Not good":
                case "not good":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "I am not feeling good today":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "Open Visual studio":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("C:\\Program Files (x86)\\AnyDesk\\AnyDesk.exe");
                    break;
                case "open calculator":
                case "Open Calculator":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("calc");
                    break;
                case "open word":
                case "Open Word":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE");
                    break;
                case "Open Notepad":
                case "open notepad":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("Notepad.exe");
                    break;
                case "open ecxel":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE");
                    break;
                case "open youtube":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("chrome.exe", "http://youtube.com");
                    break;
            }

        }
    }
}
