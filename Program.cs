/*
    Project: Virtual Assistant
    Author: Mr. Aazain
    Created Date: 8/10/2022
    .NET Version: [Insert .NET Version]

    Description:
    ------------
    This program is a simple implementation of a virtual assistant using C# and the .NET Framework.
    The assistant can recognize and respond to a predefined set of voice commands from the user.
    Speech recognition is achieved through the System.Speech.Recognition namespace, and voice
    responses are generated using the System.Speech.Synthesis namespace.

    The virtual assistant is capable of responding to greetings, inquiries about its name and designer,
    as well as performing some basic tasks such as opening common applications and a web browser.

    Main Components:
    ----------------
    1. SpeechRecognitionEngine: 
       - Configured to recognize English (U.S.) language.
       - Loads a Grammar object constructed from a set of predefined choices.
       - Asynchronously recognizes speech and triggers an event on recognition.

    2. SpeechSynthesizer:
       - Converts text to speech for the assistant's responses.
       - Used within the event handler for recognized speech.

    3. Choices and GrammarBuilder:
       - Used to define a set of valid voice commands that the assistant can recognize.

    4. Event Handler (recognizer_SpeechRecognized):
       - Handles the SpeechRecognized event.
       - Uses a switch statement to determine the appropriate response based on the recognized text.

    Usage:
    ------
    1. Run the application.
    2. Speak one of the predefined commands into the microphone.
    3. The assistant will respond accordingly, either through a voice response or by performing a task such as opening an application.

    Note:
    -----
    - Ensure that a microphone is connected and properly configured on the system.
    - The paths to applications in the code should be verified and modified according to the setup of your own system.
    - The Chrome browser should be installed and in the system's PATH for the "open youtube" command to work properly.
*/



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
        static SpeechSynthesizer my_assistant = new SpeechSynthesizer();
        static void Main(string[] args)
        {

                SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

                Choices my_choices = new Choices();
                my_choices.Add("what is your name");
                my_choices.Add("what's your name");
                my_choices.Add("who is your designer");
                my_choices.Add("hello computer");
                my_choices.Add("hello");
                my_choices.Add("hi");
                my_choices.Add("hi there");
                my_choices.Add("hey computer Welcome to the world");
                my_choices.Add("hello there");
                my_choices.Add("i am great, what about you");
                my_choices.Add("i am good");
                my_choices.Add("i am fine");
                my_choices.Add("not good");
                my_choices.Add("i am not feeling good today");
                my_choices.Add("open visual studio code");
                my_choices.Add("open calculator");
                my_choices.Add("open word");
                my_choices.Add("Open notepad");
                my_choices.Add("open excel");
                my_choices.Add("open youtube");
                GrammarBuilder grammarBuilder = new GrammarBuilder(my_choices);
                Grammar grammar = new Grammar(grammarBuilder);
                recognizer.LoadGrammar(grammar);
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                Console.WriteLine("Listening...");
                Console.ReadKey();


        }

        public static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string command = e.Result.Text.ToLower();

            switch (command)
            {
                case "hello computer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Hello Mr Aazain, it is a pleasure to meet you, How are you!");
                    break;
                case "what is your name":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("My name is Bella");
                    break;
                case "who is your designer":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("My designer is Mr Aazain");
                    break;
                case "hello":
                case "hi":
                case "hi there":
                case "hello there":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("Hi There, How are you!");
                    break;
                case "i am great, what about you":
                case "i am good":
                case "i am fine":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("That's great, please let me know what i can do for you");
                    break;
                case "not good":
                case "i am not feeling good today":
                    Console.WriteLine(e.Result.Text);
                    my_assistant.Speak("I am sorry to hear that, please let me know if i can do anything to make you feel better");
                    break;
                case "open visual studio code":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("C:\Users\Azain\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Visual Studio Code\Visual Studio Code.lnk");
                    break;
                case "open calculator":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("calc");
                    break;
                case "open word":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE");
                    break;
                case "open notepad":
                    Console.WriteLine(e.Result.Text);
                    System.Diagnostics.Process.Start("Notepad.exe");
                    break;
                case "open excel":
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
