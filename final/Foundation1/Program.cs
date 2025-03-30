using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videosList = new List<Video>();

        Video vid1 = new Video();
        vid1._title = "I Built a Car out of Scooters";
        vid1._length = "17:29";
        vid1._author = "Michael Reeves";
        Comment vid1Comment1 = new Comment();
        vid1Comment1._username = "hacksmith";
        vid1Comment1._comment = "this is what peak youtube looks like. this is a perfect video";
        Comment vid1Comment2 = new Comment();
        vid1Comment2._username = "jacksepticeye";
        vid1Comment2._comment = "Nice welds";
        Comment vid1Comment3 = new Comment();
        vid1Comment3._username = "LilyPichu";
        vid1Comment3._comment = "my chair";

        Video vid2 = new Video();
        vid2._title = "I Gave My Goldfish $50,000 to Trade Stocks";
        vid2._length = "15:18";
        vid2._author = "Michael Reeves";
        Comment vid2Comment1 = new Comment();
        vid2Comment1._username = "mistersandman2069";
        vid2Comment1._comment =  "\" Fish is outperforming the NASDAQ by 14%\" is one of the wildest lines I've heard from YouTube";
        Comment vid2Comment2 = new Comment();
        vid2Comment2._username = "Mo-xm8ci";
        vid2Comment2._comment = "We all have an extremely toxic relationship with Michael where he leave us for months but we always take him back. Actual legend";
        Comment vid2Comment3 = new Comment();
        vid2Comment3._username = "Insorainity";
        vid2Comment3._comment = "This has got to be the most complicated way for Michael to tell us he got a pet fish";

        Video vid3 = new Video();
        vid3._title = "I Built A Surgery Robot";
        vid3._length = "12:34";
        vid3._author = "Michael Reeves";
        Comment vid3Comment1 = new Comment();
        vid3Comment1._username = "ngregoirenc";
        vid3Comment1._comment = "As someone who actually does R&D for medical devices this has me crying. It’s beautiful";
        Comment vid3Comment2 = new Comment();
        vid3Comment2._username = "catatemysocks1811";
        vid3Comment2._comment = "I just realized that the on off switch says “on” and “less on”";
        Comment vid3Comment3 = new Comment();
        vid3Comment3._username = "spyaj101";
        vid3Comment3._comment = "So this must be the guy who did Kim Jong Un's surgery";

        vid1._comments.Add(vid1Comment1);
        vid1._comments.Add(vid1Comment2);
        vid1._comments.Add(vid1Comment3);

        vid2._comments.Add(vid2Comment1);
        vid2._comments.Add(vid2Comment2);
        vid2._comments.Add(vid2Comment3);

        vid3._comments.Add(vid3Comment1);
        vid3._comments.Add(vid3Comment2);
        vid3._comments.Add(vid3Comment3);

        videosList.Add(vid1);
        videosList.Add(vid2);
        videosList.Add(vid3);

        foreach (Video video in videosList)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }   
}