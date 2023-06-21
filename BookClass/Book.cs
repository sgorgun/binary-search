using System;

namespace BookClass
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book : IComparable
    {
        private readonly string author;
        private readonly string title;
        private readonly string publisher;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author of the book.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">Publisher of the book.</param>
        /// <exception cref="ArgumentNullException">Throw when author or title or publisher is null.</exception>
        public Book(string author, string title, string publisher)
        {
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="left">The first  parameter to compare.</param>
        /// <param name="right">The second parameter to compare.</param>
        /// <returns>true if the left parameter is less than the right parameter; otherwise, false.</returns>
        public static bool operator ==(Book? left, Book? right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Operator !=.
        /// </summary>
        /// <param name="left">The first parameter to compare.</param>
        /// <param name="right"> The second parameter to compare.</param>
        /// <returns> true if the left parameter is greater than or equal to the right parameter; otherwise, false.</returns>
        public static bool operator !=(Book? left, Book? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Operator less.
        /// </summary>
        /// <param name="left">The first parameter to compare.</param>
        /// <param name="right">The second parameter to compare.</param>
        /// <returns> true if the left parameter is less than the right parameter; otherwise, false.</returns>
        public static bool operator <(Book? left, Book? right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Operator less or equal.
        /// </summary>
        /// <param name="left">The first parameter to compare.</param>
        /// <param name="right">The second parameter to compare.</param>
        /// <returns>true if the left parameter is less than or equal to the right parameter; otherwise, false.</returns>
        public static bool operator <=(Book? left, Book? right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Operator greater.
        /// </summary>
        /// <param name="left">The first parameter to compare.</param>
        /// <param name="right">The second parameter to compare.</param>
        /// <returns>true if the left parameter is greater than the right parameter; otherwise, false.</returns>
        public static bool operator >(Book? left, Book? right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Operator greater or equal.
        /// </summary>
        /// <param name="left">The first parameter to compare.</param>
        /// <param name="right">The second parameter to compare.</param>
        /// <returns>true if the left parameter is greater than or equal to the right parameter; otherwise, false.</returns>
        public static bool operator >=(Book? left, Book? right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns.
        /// </summary>
        /// <param name="other">The book to compare with this instance.</param>
        /// <returns> A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(Book? other)
        {
            if (other == null)
            {
                return 1;
            }

            int titleComparison = string.Compare(this.title, other.title, StringComparison.OrdinalIgnoreCase);
            if (titleComparison != 0)
            {
                return titleComparison;
            }

            int authorComparison = string.Compare(this.author, other.author, StringComparison.OrdinalIgnoreCase);
            if (authorComparison != 0)
            {
                return authorComparison;
            }

            return string.Compare(this.publisher, other.publisher, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        /// <exception cref="ArgumentException">Throw when <paramref name="obj"/> is not a Book.</exception>
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is not Book)
            {
                throw new ArgumentException($"The object is not a Book.", nameof(obj));
            }

            return this.CompareTo((Book)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return (obj is Book book) &&
                   string.Equals(this.author, book.author, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(this.title, book.title, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(this.publisher, book.publisher, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ this.author.GetHashCode(StringComparison.OrdinalIgnoreCase);
                hash = (hash * 16777619) ^ this.title.GetHashCode(StringComparison.OrdinalIgnoreCase);
                hash = (hash * 16777619) ^ this.publisher.GetHashCode(StringComparison.OrdinalIgnoreCase);
                return hash;
            }
        }
    }
}
