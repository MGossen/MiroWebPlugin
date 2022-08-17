# MiroWebPlugin
MiroWebPlugin for Bachelor Thesis

This Project is a prototype for a bachelor thesis.
It is the implementation of a Webplugin that uses the Miro API and SDK to post stickynotes into selcted areas on the Miro board. The areas can be templates from the Miro Marketplace or templates created by yourself.

To use this Repository yourself, host this Webapp locally or on a server.
For developing purposes the Webapp can be hosted locally.

Follow the instruction on https://developers.miro.com/docs/build-your-first-hello-world-app#step-3-create-your-app-in-miro of how to create your own App. Reference the Index.html of this Webapp in the configuration under 'App URL'. The needed Scopes for the Webplugin are 'boards:read' and 'boards:write'.

When the app is installed, open a board. The Webplugin should get initialised. An App-Icon appears in the sidebar. 
When clicking the App icon, all selected Board objects get send to the Webapp and will be handled as input fields. Stickynotes can then be added ontop of the selected Objects via the Webapp.
