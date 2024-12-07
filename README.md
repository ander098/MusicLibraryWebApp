MusicLibraryWebApp
A web-based application to manage and organize your music library. Users can add songs, albums, and artists, filter songs by genres, view top-ranked songs, and browse detailed information about songs, albums, and artists.

Features
Add and manage songs, albums, and artists.
Filter songs by genre or rank.
View details for songs, albums, and artists.
iTunes-inspired dark theme design.
Prerequisites
Before running this application, ensure you have the following installed:

.NET SDK
Download the latest version from dotnet.microsoft.com.

Code Editor (Optional)

Visual Studio Code
Visual Studio
Git (Optional, if cloning from a repository)
Download from git-scm.com.

Getting Started
1. Clone or Download the Project
Clone via Git:
bash
Copy code
git clone <repository-url>
cd <repository-folder>
Download as ZIP:
Download the ZIP file from the repository.
Extract the contents into a directory of your choice.
2. Restore Dependencies
Run the following command in the project root directory to install dependencies:

bash
Copy code
dotnet restore
3. Build the Project
Compile the project to ensure there are no errors:

bash
Copy code
dotnet build
4. Run the Application
Start the application using:

bash
Copy code
dotnet run
Once started, the terminal will display the URL where the application is running, such as:

arduino
Copy code
http://localhost:5004
Open your browser and navigate to the displayed URL.

For auto-reloading during development:

bash
Copy code
dotnet watch run
5. Usage
Add Songs: Add songs with details such as title, artist, album, genre, and rank.
Filter by Genre: Use the dropdown to view songs by a specific genre.
Top-Ranked Songs: View songs ranked 8 or higher.
Song, Album, Artist Details: Click links to see detailed pages.
6. Stop the Application
To stop the application:

Go to the terminal where the application is running.
Press Ctrl + C (or Cmd + C on Mac).
