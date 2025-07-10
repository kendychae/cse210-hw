using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create video 1
        Video video1 = new Video("How to Cook Perfect Pasta", "ChefMaster", 480);
        video1.AddComment(new Comment("FoodLover123", "This recipe is amazing! I tried it and it worked perfectly."));
        video1.AddComment(new Comment("PastaPro", "Great tips on timing. The pasta came out al dente."));
        video1.AddComment(new Comment("KitchenNovice", "Finally, someone who explains it clearly. Thank you!"));
        video1.AddComment(new Comment("CookingMom", "My family loved this recipe. Making it again tonight!"));
        videos.Add(video1);

        // Create video 2
        Video video2 = new Video("10 Minute Morning Workout", "FitnessFan", 600);
        video2.AddComment(new Comment("HealthyLife", "Perfect for busy mornings. I do this every day now."));
        video2.AddComment(new Comment("WorkoutWarrior", "Love the intensity! Really gets my heart pumping."));
        video2.AddComment(new Comment("BeginnerFit", "Great for beginners like me. Not too overwhelming."));
        videos.Add(video2);

        // Create video 3
        Video video3 = new Video("JavaScript Basics Tutorial", "CodeAcademy", 1200);
        video3.AddComment(new Comment("DevStudent", "This helped me understand variables so much better!"));
        video3.AddComment(new Comment("JSLearner", "Clear explanations and good examples. Subscribed!"));
        video3.AddComment(new Comment("ProgrammerLife", "Wish I had this when I started learning JavaScript."));
        video3.AddComment(new Comment("WebDeveloper", "Great tutorial! Looking forward to the next one."));
        videos.Add(video3);

        // Create video 4
        Video video4 = new Video("Beautiful Nature Landscapes", "NaturePhotographer", 300);
        video4.AddComment(new Comment("NatureLover", "Absolutely breathtaking scenery. So peaceful to watch."));
        video4.AddComment(new Comment("PhotoEnthusiast", "Amazing shots! What camera did you use?"));
        video4.AddComment(new Comment("RelaxationSeeker", "Perfect for meditation and relaxation."));
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            
            Console.WriteLine(); // Empty line for separation
        }
    }
}