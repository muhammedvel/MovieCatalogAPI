using System;

namespace MovieCatalogAPI.Models;

public class Review
{
    private int _id;
    private string _reviewerName = string.Empty;
    private string _comment = string.Empty;
    private int _stars;
    private int _movieId;

    public int Id
    {
        get { return this._id; }
        set { this._id = value; }
    }

    public string ReviewerName
    {
        get { return this._reviewerName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Reviewer name cannot be empty!");
            }
            this._reviewerName = value;
        }
    }

    public string Comment
    {
        get { return this._comment; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Comment cannot be empty!");
            }
            this._comment = value;
        }
    }

    public int Stars
    {
        get { return this._stars; }
        set
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentException("Stars must be between 1 and 5.");
            }
            this._stars = value;
        }
    }

    public int MovieId
    {
        get { return this._movieId; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid Movie ID.");
            }
            this._movieId = value;
        }
    }
}