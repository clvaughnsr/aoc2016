using System;

namespace AOC2016.Day08
{
    class Display
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool[,] _pixels;
        private int _width;
        private int _height;

        // CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Display()
        {
            const int DEFAULT_WIDTH = 50;
            const int DEFAULT_HEIGHT = 6;

            _width = DEFAULT_WIDTH;
            _height = DEFAULT_HEIGHT;
            _pixels = new bool[_height, _width];

            AllOff();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Display(int inWidth, int inHeight)
        {
            _width = inWidth;
            _height = inHeight;
            _pixels = new bool[_height, _width];

            AllOff();
        }
        // METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Rectangle(int inWidth, int inHeight)
        {
            for (int row = 0; row < inHeight; row++)
            {
                for (int col = 0; col < inWidth; col++)
                {
                    _pixels[row, col] = true;
                }
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void RotateRow(int inRow, int inVal)
        {
            for (int i = 0; i < inVal; i++)
            {
                var tempVal = _pixels[inRow, _width - 1];

                for (int col = _width - 1; col > 0; col--)
                {
                    _pixels[inRow, col] = _pixels[inRow, col - 1];
                }

                _pixels[inRow, 0] = tempVal;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void RotateColumn(int inCol, int inVal)
        {
            for (int i = 0; i < inVal; i++)
            {
                var tempVal = _pixels[_height - 1, inCol];

                for (int row = _height - 1; row > 0; row--)
                {
                    _pixels[row, inCol] = _pixels[row - 1, inCol];
                }

                _pixels[0, inCol] = tempVal;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void AllOff()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    _pixels[row, col] = false;
                }
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int Count()
        {
            var outCount = 0;

            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    if (_pixels[row, col] == true)
                    {
                        outCount++;
                    }
                }
            }

            return outCount;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Output()
        {
            Console.WriteLine();

            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    if (_pixels[row, col])
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
