using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pairProgrammingØvelse
{
    public class Record
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int PublicationYear { get; set; }

        public Record(string title, string artist, int duration, int publicationYear)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }

        public void ValidateTitle()
        {
            if (Title == null)  throw new ArgumentNullException("Title cannot be null or empty");
        }
        public void ValidateArtist()
        {
            if (Artist == null) throw new ArgumentNullException("Artist cannot be null or empty");
        }
        public void ValidateDuration()
        {
            if (Duration <= 0) throw new ArgumentOutOfRangeException("Duration cannot be less than or equal to 0");
        }
        public void ValidateYear()
        {
            if (PublicationYear > 2024) throw new ArgumentOutOfRangeException("Year cannot be newer than 2024");
        }

        public void Validate()
        {
            ValidateTitle();
            ValidateArtist();
            ValidateDuration();
            ValidateYear();
        }

        public Record()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Title)}={Title}, {nameof(Artist)}={Artist}, {nameof(Duration)}={Duration.ToString()}, {nameof(PublicationYear)}={PublicationYear.ToString()}}}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Record record &&
                   Title == record.Title &&
                   Artist == record.Artist &&
                   Duration == record.Duration &&
                   PublicationYear == record.PublicationYear;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Artist, Duration, PublicationYear);
        }
    }
}
