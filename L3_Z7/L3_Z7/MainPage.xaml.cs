using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace L3_Z7
{

    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        string tekst;
        MediaElement mediaElement;
        public MainPage()
        {
             tekst = File.ReadAllText("tekst1.txt");
            mediaElement = new MediaElement();
            this.InitializeComponent();
        }

        private async void Button_Click_F(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            var syn = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
           
            
           
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stm =
                await syn.SynthesizeTextToStreamAsync(tekst);
            mediaElement.SetSource(stm, stm.ContentType);
            mediaElement.Play();
        }
        private async void Button_Click_M(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            var syn = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            
            VoiceInformation voiceInfo = (from voice in SpeechSynthesizer.AllVoices
                                          where voice.Gender == VoiceGender.Male
                                          select voice).FirstOrDefault() ?? SpeechSynthesizer.DefaultVoice;
            
            
            syn.Voice = voiceInfo;
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stm =
                await syn.SynthesizeTextToStreamAsync(tekst);
           
            mediaElement.SetSource(stm, stm.ContentType);
            mediaElement.Play();
        }

        
        
}
    }
}
