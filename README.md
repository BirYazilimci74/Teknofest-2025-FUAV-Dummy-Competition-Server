# Competition Server Simulation for Teknofest Fighter UAV Competition

This repo is Competition server simulation for Teknofest Fighter UAV Competition. It is built using ASP.NET Core

To run it, 

Navigate to the project folder and write "dotnet watch run" to terminal.

Available endpoints for now:

- GET QR Coordinate:		http://localhost:5259/api/qr_koordinati
- GET Server Time:		http://localhost:5259/api/sunucusaati
- GET Air Defense Field:	http://localhost:5259/api/hss_koordinatlari
- POST Lock:			http://localhost:5259/api/kilitlenme_bilgisi
- POST Kamikaze:		http://localhost:5259/api/kamikaze_bilgisi
- POST Enterence:		http://localhost:5259/api/giris
- POST Send Telemetry:		http://localhost:5259/api/telemetri_gonder


Server time is updating every one second.

Each POST endpoint has its own GET endpoint (except enterence) for checking.

giris gives a response {"takimNumarasi": 1} for all login.
