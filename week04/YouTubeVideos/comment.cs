using System;
using System.Collections.Generic;

// The Comment class represents a single comment on a video.
// It encapsulates the commenter's name and the text of the comment.
public class Comment
{
    // Private fields to store the comment data.
    private string _name;
    private string _text;

    // Constructor to initialize a new comment.
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Public method to get the commenter's name.
    public string GetName()
    {
        return _name;
    }

    // Public method to get the comment's text.
    public string GetText()
    {
        return _text;
    }
}