using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SharpAudio;
using SharpAudio.Codec;


namespace Client
{
    class AudioManager
    {
        public static void PlayStereo(string path, float volume)
        {
            var engine = AudioEngine.CreateDefault();
            var soundStream = new SoundStream(File.OpenRead(path), engine);

            soundStream.Volume = volume;
            soundStream.Play();
        }

    }

}
