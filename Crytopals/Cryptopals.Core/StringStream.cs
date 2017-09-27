using System;
using System.IO;
using System.Text;

namespace Cryptopals.Core
{
    public class StringStream : Stream
    {
        readonly string _string;
        readonly Encoding _encoding;
        readonly long _byteLength;
        int _position;

        public StringStream(string contents, Encoding encoding = null)
        {
            _string = contents ?? string.Empty;
            _encoding = encoding ?? Encoding.ASCII;
            _byteLength = _encoding.GetByteCount(_string);
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _byteLength;

        public override long Position {
            get => _position;
            set {
                if (value >= 0 && value <= int.MaxValue) _position = (int) value;
                else throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.End:
                    Position = _byteLength + offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
            }

            return Position;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_position < 0)
            {
                throw new InvalidOperationException();
            }

            var bytesRead = 0;
            var chars = new char[1];
            
            while (bytesRead < count && _position < _string.Length)
            {
                chars[0] = _string[_position];
                
                var byteCount = _encoding.GetByteCount(chars);
                
                if (bytesRead + byteCount > count)
                {
                    return bytesRead;
                }
                
                _encoding.GetBytes(chars, 0, 1, buffer, offset + bytesRead);
                
                Position++;
                bytesRead += byteCount;
            }

            return bytesRead;
        }

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override void Flush() => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();
    }
}
