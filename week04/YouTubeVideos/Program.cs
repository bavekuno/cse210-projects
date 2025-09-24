using System;
using System.Collections.Generic;


// Program class contains the Main method, which is the entry point of the application.
// It creates video and comment objects and displays their information.
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold all the video objects.
        List<Video> videos = new List<Video>();

        // Create the first video and add comments.
        Video video1 = new Video("C# Classes Explained", "CodeMentor Alex Joe", 650);
        video1.AddComment(new Comment("Alice", "This was a super helpful explanation!"));
        video1.AddComment(new Comment("Bob", "The examples were really clear."));
        video1.AddComment(new Comment("Charlie", "Thanks for the great content!"));
        videos.Add(video1);

        // Create the second video and add comments.
        Video video2 = new Video("Introduction to Data Structures", "TechTutor Mary Alice", 1200);
        video2.AddComment(new Comment("Diana", "I'm a beginner and this made sense."));
        video2.AddComment(new Comment("Ethan", "The time complexity section was fantastic."));
        video2.AddComment(new Comment("Fiona", "Could you do a video on algorithms next?"));
        videos.Add(video2);

        // Create the third video and add comments.
        Video video3 = new Video("Advanced C++ Pointers", "C++ Master Brian Mars", 980);
        video3.AddComment(new Comment("George", "This is very detailed. Love it!"));
        video3.AddComment(new Comment("Hannah", "The diagrams helped a lot."));
        video3.AddComment(new Comment("Ian", "Finally, a good explanation of this topic."));
        videos.Add(video3);

        // Create the fourth video and add comments.
        Video video4 = new Video("Web Development Basics", "Web Developer Alex Smith", 750);
        video4.AddComment(new Comment("Judy", "Perfect for a quick review."));
        video4.AddComment(new Comment("Kevin", "What frameworks should I learn after this?"));
        video4.AddComment(new Comment("Laura", "Short and to the point. Great job!"));
        video4.AddComment(new Comment("Mike", "This helped me on my coding assignment."));
        videos.Add(video4);

        // Iterate through the list of videos and display their information.
        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            // Iterate through each video's comments and display them.
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
