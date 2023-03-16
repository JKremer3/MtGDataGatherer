# MtG Data Gatherer

Small App to help gather data on your Magic The Gathering Deck without needing to fill out an excel sheet.
Currently this app is a Web API than can receive a single card name, or a list of card names, and retrieve information from Wizards of the Coast's Magic API

# Routes

## [GET]  /cards/cardtypes
Retrieves a list of card types from the MTG API.

## [GET]  /cards/{cardName}
Retrieves card data for the specified card. If the name is not valid, a blank data set is returned.

## [POST] /cards/list
Retrieves card data for a list of card names in the request body. Invalid names are skipped over.

## [POST] /cards/list/manadata
Calculates Average Combined Mana Cost, Mana Color Pip Count, and Mana Color Ratio for a list of cards.
 
# TO-DO
- Implement unit tests
- Add Data processing for land source counts. 
- Make small query optimizations
- Implement a Frontend page for ease of use.
- Implement the saving of card data sets, to save on load times. 
