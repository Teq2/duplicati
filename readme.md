# Duplicati 1.3.x with Google Drive support
------

Original *v1.3.x* (forked from [original repo](https://github.com/duplicati/duplicati/tree/1.3.x)) with **Google drive** (+ **OAuth2**) backend backported from duplicati's v2.0 branch. 

Summary changes:
* Google drive api client fully backported from *v2.0*
* OAuth2 backend (actually a duplicati-oauth-handler.appspot.com client) backported from *v2.0*
* Framework target changed from *v4.5* to *v2.0* (which is used by *v1.3.4* branch)
* New UI page added for this backend

You can add these **Google drive** and **OAuth2** backends manually to your installed *Duplicati v1.3.4*, all what you need is 4 new dll's:
1. Duplicati.Library.Backend.GoogleDrive_v2.dll
2. Duplicati.Library.OAuthHelper.dll
3. LINQlone.dll
4. Newtonsoft.Json.dll

You can [download](https://github.com/Teq2/duplicati/releases/download/1.3.x/Duplicati.Library.Backend.GoogleDrive.zip) them from releases page or compile modules manually and put them into a /Duplicati/ directory.
