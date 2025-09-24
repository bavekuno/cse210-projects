using System;
using System.Collections.Generic;

// The Video class represents a YouTube video.
// It encapsulates the video's title, author, length, and a list of its comments.
public class Video
{
    // Private fields to store the video data.
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor to initialize a new video.
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Public method to add a new comment to the video's list of comments.
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Public method to get the total number of comments on the video.
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Public method to get the list of comments for the video.
    public List<Comment> GetComments()
    {
        return _comments;
    }

    // Public method to get the video's title.
    public string GetTitle()
    {
        return _title;
    }

    // Public method to get the video's author.
    public string GetAuthor()
    {
        return _author;
    }

    // Public method to get the video's length in seconds.
    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }
}
