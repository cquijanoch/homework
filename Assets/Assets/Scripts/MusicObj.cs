using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObj : MonoBehaviour {

    private decimal columnX;
    private decimal columnY;
    private decimal columnZ;

    private decimal columnArtistHotness;
    private double columnTempo;
    private decimal columnFamiliarity;
    private decimal columnDuration;
    private decimal columnLoudness;
    private string columnTerms;
    private int columnMode;
    private double columnKey;
    private int columnYear;
    private string columnTitle;
    private string columnLocation;
    private string columnArtistName;
    private string columnReleaseName;
    private decimal columnSongHotness;
    private bool theOne;

    private Color color;


    public decimal ColumnX { get { return columnX; } set { columnX = value; } }
    public decimal ColumnY { get { return columnY; } set { columnY = value; } }
    public decimal ColumnZ { get { return columnZ; } set { columnZ = value; } }

    public decimal ColumnArtistHotness { get { return columnArtistHotness; } set { columnArtistHotness = value; } }
    public double ColumnTempo { get { return columnTempo; } set { columnTempo = value; } }
    public decimal ColumnFamiliarity { get { return columnFamiliarity; } set { columnFamiliarity = value; } }
    public decimal ColumnDuration { get { return columnDuration; } set { columnDuration = value; } }
    public decimal ColumnLoudness { get { return columnLoudness; } set { columnLoudness = value; } }
    public string ColumnTerms { get { return columnTerms; } set { columnTerms = value; } }
    public int ColumnMode { get { return columnMode; } set { columnMode = value; } }
    public double ColumnKey { get { return columnKey; } set { columnKey = value; } }
    public int ColumnYear { get { return columnYear; } set { columnYear = value; } }
    public string ColumnTitle { get { return columnTitle; } set { columnTitle = value; } }
    public string ColumnLocation { get { return columnLocation; } set { columnLocation = value; } }
    public string ColumnArtistName { get { return columnArtistName; } set { columnArtistName = value; } }
    public string ColumnReleaseName { get { return columnReleaseName; } set { columnReleaseName = value; } }
    public decimal ColumnSongHotness { get { return columnSongHotness; } set { columnSongHotness = value; } }

    public Color Color { get; set; }
    public Color CurrentColor { get; set; }
    public bool TheOne { get; set; }

}
