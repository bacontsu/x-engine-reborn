using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Numerics;
using SharpAudio;
using SharpAudio.Codec;
using NetCoreServer;


namespace Client
{
    class AudioManager
    {
        public static AudioEngine engine = AudioEngine.CreateDefault();
        public static Audio3DEngine audio3d = engine.Create3DEngine();

        public static void PlayStereoSound(string path, float volume)
        {
            var soundStream = new SoundStream(File.OpenRead(path), engine);

            soundStream.Volume = volume;
            soundStream.Play();
        }

        public static void UpdateListener(Vector3 playerPos, Vector3 playerAng)
        {
            (Vector3 forward, Vector3 up, Vector3 right) = Mathlib.AngleVectors(playerAng);
            audio3d.SetListenerPosition(playerPos);
            audio3d.SetListenerOrientation(up, forward);
        }

        public static void Play3DSound(string path, float volume, Vector3 pos)
        {
            // not ready yet
        }

    }

}
