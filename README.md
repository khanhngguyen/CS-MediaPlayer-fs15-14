# Media Player Application

Build a media player application that demonstrates advanced topics in C# programming, including solid, clean architecture, Factory pattern, Singleton pattern, Observer pattern, object lifetime, and thread safety.

## Description

The media player application is a robust software that meets the requirements by providing essential functionalities:

1. Playback Functionality:

- Users should be able to play audio and video files.
- Provide controls for play, pause, stop, and seek functionality.
- Display the current playback status, such as the current position and duration.

2. Media Management:

- Users should be able to manage their media library, including adding, removing, and organizing media files.
- Implement features to manage playlists.

3. Command-Line Interface:

- Design a user-friendly command-line interface that allows users to navigate and interact with the application.
- Provide clear instructions and feedback to guide users through different operations.

4. Error Handling:

- Handle potential errors and exceptions gracefully, providing meaningful error messages to the user.

## Requirements:

- Design a solid and clean architecture for the media player application.
- Implement the Factory pattern to create different types of media players, such as audio player and video player.
- Implement the Singleton pattern to ensure there is only one instance of the media player manager throughout the application.
- Implement the Observer pattern to allow the media player manager to notify other components of the application about playback events, such as play, pause, and stop.
- Manage object lifetimes appropriately.
- Ensure thread safety by handling concurrent access to shared resources, such as the media player manager.

## Result
### Brief
Media Player Application is an app where user can manage media files and custom their Playlists
- The app has:
    - A library contains all media files
    - A library contains all the Playlists
- Media files can either be Audio (.mp3 format) or Video (.mp4 format)
- User can play/pause/stop each file individually
- Or user can create their own Playlist and custom the playlist by adding files & deleting files into it
- If user choose to play a Playlist, user can control it by input commands


### Demo photos
Set up example Media Player App with files & Playlists
![Set up Media Player](./demo%20photos/set%20up%20Media%20Player.png)

User can interact/control each media file individually
![Control each media file](./demo%20photos/control%20each%20file.png)

Scenenario: User creates a Playlist named "New Jeans" and wants to add media files that related to New Jeans only
![Custom a Playlist](./demo%20photos/custom%20a%20Playlist.png)

Inside "New Jeans" Playlist, user can interact/control using commands
![Playlist CLI](./demo%20photos/Playlist%20CLI.png)
