namespace PracticeExercise1;

public class ArrayList : IList
{
    private int[] array;
    private int length;

    public ArrayList()
    {
        array = new int[16];
        length = 0;
    }

    /// <summary>
    /// Returns first element in list, null if empty.
    /// </summary>
    public int? First => IsEmpty ? null : array[0];

    // TODO
    /// <summary>
    /// Returns last element in list, null if empty.
    /// </summary>
    public int? Last => IsEmpty ? null : array[length - 1];

    /// <summary>
    /// Returns true if list is has no elements; false otherwise.
    /// </summary>
    public bool IsEmpty => length == 0;

    /// <summary>
    /// Number of elements in list.
    /// </summary>
    public int Length => length;

    // TODO 
    /// <summary>
    /// Adds given value to end of list.
    /// </summary>
    /// <param name="value">value to add to the list</param>
    public void Append(int value)
    {
        array[length] = value;
        length++;

        if( length == array.Length)
        {
            Resize();
        }
    }

    /// <summary>
    /// Checks if the list contains the given value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>true if value is in list; false otherwise</returns>
    public bool Contains(int value)
    {
        for( int i = 0; i < length; i++)
        {
            if(array[i] == value)
            {
                return true;
            }
        }
        return false;
    }

    // TODO
    /// <summary>
    /// Find index of first element with matching value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Index of first element with value; -1 if element is not found</returns>
    public int FirstIndexOf(int value)
    {
        for(int i=0; i < length; i++)
        {
            if(array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    // TODO
    /// <summary>
    /// Insert new value after first instance of existing value.
    /// If existingValue is not in list, then add new value to end of list.
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="existingValue"></param>
    public void InsertAfter(int newValue, int existingValue)
    {
        int index = FirstIndexOf(existingValue);

        if (index == -1)
        {
            Append(newValue);
            return;
        }
        if (length == array.Length)
        {
            Resize();
        }
        
        ShiftRight(index + 1);
        array[index + 1] = newValue;
        length++;
    }
    

    // TODO
    /// <summary>
    /// Insert value at given index 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    public void InsertAt(int value, int index)
    {
        if (index < 0 || index > length)
        {
            throw new IndexOutOfRangeException();
        }

        if (length == array.Length)
        {
            Resize();
        }
        
        ShiftRight(index);
        array[index] = value;
        length++;
    }

    /// <summary>
    /// Add value to beginning of list
    /// </summary>
    /// <param name="value"></param>
    public void Prepend(int value)
    {
        if( length == array.Length)
        {
            Resize();
        }
        ShiftRight(0);
        array[0] = value;
        length++;
    }

    // TODO
    /// <summary>
    /// Remove first item with given value
    /// </summary>
    /// <param name="value">value of item to be removed</param>
    public void Remove(int value)
    {
        int index = FirstIndexOf(value);
        if(index >= 0)
        {
            RemoveAt(index);
        }
    }

    // TODO
    /// <summary>
    /// Remove item at specififed index.
    /// </summary>
    /// <param name="index"></param>
    /// <exception > Throws IndexOutOfRangeException </exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= length)
        {
            throw new IndexOutOfRangeException();
        }
        ShiftLeft(index); 
        length--;
    }

    public override string ToString()
    {
        string str = "[ ";

        for (int i = 0; i < Length - 1; i++)
        {
            str += array[i] + ", ";
        }

        if (!IsEmpty)
        {
            str += array[Length - 1];
        }

        str += "]";

        return str;
    }

    /// <summary>
    /// Return the element at the given index or null if the index is out of range.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The element at the given index; null if index is negative or not less than Length.</returns>
    public int? Get(int index)
    {
        if (index < 0 || index >= length)
        {
            return null;
        }
        return array[index];
    }

    /// <summary>
    /// Remove all elements from list
    /// </summary>
    public void Clear()
    {
        length = 0;
    }

    /// <summary>
    /// Return a new copy of list in reverse order
    /// </summary>
    /// <returns></returns>
    public IList Reverse()
    {
        ArrayList reversedArray = new ArrayList();

        for(int i = length-1; i >= 0; i--)
        {
            reversedArray.Append(array[i]);
        }
        return reversedArray;
    }

    private void ShiftRight(int startingIndex)
    {
        for(int i = length-1; i >= startingIndex; i--)
        {
            array[i+1] = array[i];
        }
    }

    private void ShiftLeft(int startingIndex)
    {
        for (int i = startingIndex; i < length - 1; i++)
        {
            array[i] = array[i+1];
        }
    }

    private void Resize()
    {
        Array.Resize(ref array, 2 * array.Length);
    }
}


