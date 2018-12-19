

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TLGFPowerBooks;

public class BookControllerHN : MonoBehaviour
{

    public PBook pBook;
    public bool bookIsOpen = false;
    public bool isLastPage = false;



    /*
     // code copied from EXAMPLEKEYBOARDCONTROLLER
    if (openCloseKey != KeyCode.None && Input.GetKeyDown(openCloseKey)) {
            if (pBook.GetBookState () == PBook.BookState.CLOSED) {
                pBook.OpenBook();
            }
            if (pBook.GetBookState () == PBook.BookState.OPEN) {
                pBook.CloseBook();
            }
        }
*/

    /* need to open and close book using Update as book takes time to close and open
    not working though - and can't close book - except by using coloured cube/bar 
    but just leave for moment
   */
    
        void Update()
    {
        //Debug.Log("In BookControllerHN / Update");
       /*
        if (!bookIsOpen)
        {
            pBook.OpenBook();
            bookIsOpen == true;
        }

        if (bookIsOpen && isLastPage)
        {
            pBook.CloseBook();
            bookIsOpen = false;
        }
        */
    }



    public void OpenBook()
        {
        Debug.Log("In BookControllerHN / OpenBook()");
            if (!bookIsOpen)
            {
                pBook.OpenBook();
                bookIsOpen = true;
            }
        }

    public void CloseBook()
    {
        if (bookIsOpen)
        {
            pBook.CloseBook();
            bookIsOpen = false;
        }
    }


    public void OpenCloseBook()
    {
        if (!bookIsOpen)
        {
            pBook.OpenBook();
            bookIsOpen = true;
        }
        else
        {    
        pBook.CloseBook();
            bookIsOpen = false;
        }
    }

    public void NextPage()
    {
        isLastPage  = pBook.IsLastPage();
        if (!isLastPage)
        {
                pBook.NextPage();
        }
        else
        {
            pBook.CloseBook();
            bookIsOpen = false;
        }
    }
   /*
    public void CloseBookOnLastPage()
    // need to find a way of closing book with GVR
    {
        
    }
    */

    public void PrevPage()
    {
        pBook.PrevPage();
    }

    public void GoToLastPage()
    {
        pBook.GoToLastPage(50);
    }

    public void GoToFirstPage()
    {
        pBook.GoToFirstPage(50);
    }

    public void JumpToLastPage()
    {
        pBook.JumpToLastPage(true);
    }

    public void JumpToFirstPage()
    {
        pBook.JumpToFirstPage(true);
    }

}


    