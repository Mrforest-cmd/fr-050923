using System;

public interface IMediaPlayer
{
    void PlayVideo(string videoFile);
    void PlayAudio(string audioFile);
}

public class MediaPlayer : IMediaPlayer
{
    public void PlayVideo(string videoFile)
    {
        Console.WriteLine($"Playing video: {videoFile}");
    }

    public void PlayAudio(string audioFile)
    {
        Console.WriteLine($"Playing audio: {audioFile}");
    }
}

public class LegacyPlayer
{
    public void PlayOldAudioFormat(string audioFile)
    {
        Console.WriteLine($"Playing old audio format: {audioFile}");
    }
}

public class AudioAdapter : IMediaPlayer
{
    private readonly LegacyPlayer _legacyPlayer;

    public AudioAdapter(LegacyPlayer legacyPlayer)
    {
        _legacyPlayer = legacyPlayer;
    }

    public void PlayVideo(string videoFile)
    {
        throw new NotImplementedException();
    }

    public void PlayAudio(string audioFile)
    {
        _legacyPlayer.PlayOldAudioFormat(audioFile);
    }
}

public interface IMediaDevice
{
    void PowerOn();
    void PowerOff();
    void SetVolume(int volume);
}

public class TV : IMediaDevice
{
    public void PowerOn()
    {
        Console.WriteLine("TV is turned on.");
    }

    public void PowerOff()
    {
        Console.WriteLine("TV is turned off.");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"TV volume set to {volume}.");
    }
}

public class Speakers : IMediaDevice
{
    public void PowerOn()
    {
        Console.WriteLine("Speakers are turned on.");
    }

    public void PowerOff()
    {
        Console.WriteLine("Speakers are turned off.");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Speaker volume set to {volume}.");
    }
}

public abstract class MediaControl
{
    protected IMediaDevice _device;

    public MediaControl(IMediaDevice device)
    {
        _device = device;
    }

    public abstract void Play();
    public abstract void Pause();
    public abstract void Stop();
}

public class VideoMedia : MediaControl
{
    public VideoMedia(IMediaDevice device) : base(device) { }

    public override void Play()
    {
        _device.PowerOn();
        Console.WriteLine("Playing video...");
    }

    public override void Pause()
    {
        Console.WriteLine("Video paused.");
    }

    public override void Stop()
    {
        Console.WriteLine("Video stopped.");
        _device.PowerOff();
    }
}

public class AudioMedia : MediaControl
{
    public AudioMedia(IMediaDevice device) : base(device) { }

    public override void Play()
    {
        _device.PowerOn();
        Console.WriteLine("Playing audio...");
    }

    public override void Pause()
    {
        Console.WriteLine("Audio paused.");
    }

    public override void Stop()
    {
        Console.WriteLine("Audio stopped.");
        _device.PowerOff();
    }
}

public class HomeTheaterFacade
{
    private readonly IMediaPlayer _mediaPlayer;
    private readonly IMediaDevice _tv;
    private readonly IMediaDevice _speakers;
    private readonly MediaControl _videoControl;
    private readonly MediaControl _audioControl;

    public HomeTheaterFacade(IMediaPlayer mediaPlayer, IMediaDevice tv, IMediaDevice speakers)
    {
        _mediaPlayer = mediaPlayer;
        _tv = tv;
        _speakers = speakers;
        _videoControl = new VideoMedia(_tv);
        _audioControl = new AudioMedia(_speakers);
    }

    public void WatchMovie(string movieFile)
    {
        Console.WriteLine("Watching a movie...");
        _mediaPlayer.PlayVideo(movieFile);
        _videoControl.Play();
        _speakers.SetVolume(50);
    }

    public void StopMovie()
    {
        Console.WriteLine("Stopping the movie...");
        _videoControl.Stop();
        _speakers.SetVolume(0);
    }

    public void ListenToMusic(string audioFile)
    {
        Console.WriteLine("Listening to music...");
        _mediaPlayer.PlayAudio(audioFile);
        _audioControl.Play();
        _speakers.SetVolume(30);
    }

    public void StopMusic()
    {
        Console.WriteLine("Stopping the music...");
        _audioControl.Stop();
        _speakers.SetVolume(0);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMediaPlayer mediaPlayer = new MediaPlayer();
        IMediaDevice tv = new TV();
        IMediaDevice speakers = new Speakers();
        LegacyPlayer legacyPlayer = new LegacyPlayer();
        IMediaPlayer audioAdapter = new AudioAdapter(legacyPlayer);

        HomeTheaterFacade homeTheater = new HomeTheaterFacade(mediaPlayer, tv, speakers);

        homeTheater.WatchMovie("movie.mp4");
        homeTheater.StopMovie();

        homeTheater.ListenToMusic("music.mp3");
        homeTheater.StopMusic();

        audioAdapter.PlayAudio("oldSong.wav");
    }
}