using System;

namespace MovieCatalogAPI.Models;

public class Movie
{
    private int id;
    private string title = null!;
    private string director = null!;
    private int releaseYear;
    private string? genre;
    private double rating;

    public Movie()
    {
    }

    public Movie(string title, string director, int releaseYear, string? genre, double rating)
    {
        this.Title = title;
        this.Director = director;
        this.ReleaseYear = releaseYear;
        this.Genre = genre;
        this.Rating = rating;
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string Title
    {
        get { return this.title; }
        set 
        { 
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title cannot be empty!");
            }
            this.title = value; 
        }
    }

    public string Director
    {
        get { return this.director; }
        set 
        { 
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Director cannot be empty!");
            }
            this.director = value; 
        }
    }

    public int ReleaseYear
    {
        get { return this.releaseYear; }
        set 
        { 
            if (value < 1888 || value > 2026)
            {
                throw new ArgumentException("Invalid release year! Must be between 1888 and 2026.");
            }
            this.releaseYear = value; 
        }
    }

    public string? Genre
    {
        get { return this.genre; }
        set { this.genre = value; }
    }

    public double Rating
    {
        get { return this.rating; }
        set 
        { 
            if (value < 0.0 || value > 10.0)
            {
                throw new ArgumentException("Rating must be between 0.0 and 10.0!");
            }
            this.rating = value; 
        }
    }
}