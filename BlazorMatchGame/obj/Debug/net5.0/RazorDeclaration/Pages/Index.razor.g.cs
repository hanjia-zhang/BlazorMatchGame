// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorMatchGame.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using BlazorMatchGame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using BlazorMatchGame.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 69 "/Users/zhanghanjia/Desktop/C# /week1/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
      
    List<string> animalEmoji = new List<string>()
{
        "🐶","🐶",
        "🐺","🐺",
        "🦊","🦊",
        "🐮","🐮",
        "🐱","🐱",
        "🦁","🦁",
        "🐯","🐯",
        "🐹","🐹",
    };

    List<string> shuffledAnimals = new List<string>();

    //set up trackers which is going to track the number of matches the player's found
    int matchesFound = 0;

    //Set up the timer, keep track of the elapsed time
    Timer timer;
    int tenthsOfSecondsElapsed = 0;
    string timeDisplay;

    //How frequently to "tick" and what method to call
    protected override void OnInitialized()
    {
        timer = new Timer(100);
        timer.Elapsed += Timer_Tick;
        SetUpGame();
    }

    //control the game elements hide or not by using bool
    bool isShow = true;
    bool gameon = false;

    private void SetUpGame()
    {
        //hide the "Win" message and restart button
        gameon = false;
        //display the main game content
        isShow = true;

        //call random
        Random random = new Random();
        shuffledAnimals = animalEmoji.OrderBy(item => random.Next()).ToList();

        //when the game is set up or reset, it resets the number of matches back to zero
        matchesFound = 0;
        tenthsOfSecondsElapsed = 150;
    }


    //Track the user inputs(total game rounds)
    public string totalRounds = " ";

    //Default game round is 1
    public int number = 1;

    private void UpdateTotalRounds(ChangeEventArgs e)
    {
        totalRounds = e.Value.ToString();

        //default the rounds with out user inputs
        if (Convert.ToInt32(totalRounds) == 0)
        {
            number = 1;
        }

        //convert the user inputs to int
        else
        {
            number = Convert.ToInt32(totalRounds);
        }
    }

    string lastAnimalFound = string.Empty;

    // Add "tag" for each gameobject
    string lastDescription = string.Empty;

    //Set up the counter to track the Total game rounds
    int counter = 0;

    private void ButtonClick(string animal, string animalDescription)
    {
        if (lastAnimalFound == string.Empty)
        {
            // First selection of the pair
            lastAnimalFound = animal;
            lastDescription = animalDescription;

            //Start the timer when the player clicks the first emoji button
            timer.Start();
        }

        // new conditions : only the same emoji but with different "worldsapce" will be matched
        else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
        {
            // Match found & Replace for next pair
            lastAnimalFound = string.Empty;

            // Replace found animals with empty string to hide them
            shuffledAnimals = shuffledAnimals.Select(a => a.Replace(animal, string.Empty)).ToList();

            //Every time the player finds a match this block adds 1 to matchesFound. If all 8 matches are found, it resets the game
            matchesFound++;
            if (matchesFound == 8)
            {
                //Stop the timer and display the message after the player finds the last match
                timer.Stop();
                timeDisplay += "- Play Again?";

                counter++;
                SetUpGame();

                //when the rounds achived the total amount rounds, display or hidden game elements
                if (counter == number)
                {
                    //display the "win" message and restart button
                    isShow = false;

                    //Hide game main content
                    gameon = true;

                    //reset counter
                    counter = 0;
                }
            }
        }

        else
        {
            // Reset the first selected emoji
            lastAnimalFound = string.Empty;
        }
    }

    //let timer know what to do each time it ticks(count down)
    private void Timer_Tick(Object source, ElapsedEventArgs e)
    {
        InvokeAsync(() =>
        {
            //count down
            tenthsOfSecondsElapsed--;

            //Trigger a function ever 1/10th of a second. Subtract 1/10 from time display
            timeDisplay = (tenthsOfSecondsElapsed / 10f).ToString("0.0s");

            //if times up reset the game
            if (tenthsOfSecondsElapsed <= 0)
            {
                SetUpGame();
            }
            StateHasChanged();
        });
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
