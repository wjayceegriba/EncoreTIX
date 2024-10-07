# EncoreTIX

Technical Exam

Frameworks / Packages Used

- EncoreTIX.Server

* AutoMapper 13.0.1
* Newtonsoft.Json 13.0.3
* Swashbuckle.AspNetCore 6.8.1

- EncoreTIX.Client

* Microsoft.AspNetCore.WebUtilities

Version : .Net EF Core 6.0
Project Type : Blazor WebAssembly Standalone App

To run the project

- Make sure a Visual Studio 2022 is installed.
- Make sure to have at least .Net EF Core version 6.
- Open the project.
- Make sure EncoreTIX.Server is selected before clicking Run button.
- Once browser opens, type PHISH or any value on the Search box.
  > If no Discover API returns no result, a message will be displayed base from figma mock up screen
- Select a card / record and click Select button.
- Details page displays the ff:
  > Attraction Name
  > Attraction Image => the first image from the lsit of images returned by API
  > Attraction Image List
  > Upcoming Events => Count and Details including :
  >
  > > Event Name
  > > Event Date & Time
  > > Venue Name
  > > Attraction External Links => clickable

To test API, do the ff:

- Run project.
- Add "/swagger/index.html" on the Url bar
- Test API by selecting and endpoint and clicking "Try out" button

Work Progress Log

- Saturday
  10:01PM - 12:42AM

  > List Attraction API (Id, Name, Image)

- Sunday
  6:35PM - 12:32AM

  > Details Attraction API (Name, Image)
  > List Upcoming Events (Name, Date, Venue)

- Monday
  9:00AM - 12:00PM
  > Designing of Card, Card Listing
  > Designing of Details page
  > 1:30PM - 6:30PM
  > Integration of endpoints (Listing by Keyword, Attraction Details including Events, Venue and External Links)
  > 8:30PM - 9:10PM Final adjustments on Details page design
  > Reviewing of installed frameworks for documentation
