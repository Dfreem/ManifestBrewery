## User Stories 
---
### Instructions

#### Format
***As a __________ (role) I want to __________ (action) so that I can __________ (rationale).***

#### ex:
##### **As a Pub Employee, I want to**: 
- See what’s available as well as what’s off limits in beer inventory,
- so when I blow a keg I know what I can replace it with. 
- To that end I need to be able to 
	-  Reserve a keg before I go to the brewery to pull it from inventory.
	-  Change the status of a keg held in inventory in the pub from “held” to “tapped” 
	- See what’s been ordered and when the batch is expected to be finished.
	  
##### **As a Sales Team Member, I want to**:
- See what’s in inventory so I can effectively sell to each of my accounts. 
- To that end I need to be able to
	-  See what’s in inventory to be sold. 
	- I need to be able to see kegs as well as cases of cans. 
	- See what’s being brewed now as well as what is scheduled to be brewed and when everything is expected to be finished. 
	- Change the status of an item in inventory from reserved to sold or back to available.
	- See a history of my sales so I can evaluate my progress toward my sales targets. 

##### **As a Brewer, I want to**:
- See a list of ingredients that are low in inventory so that I can order the ingredients that are needed.

---
### Goal / Purpose

#### Notes
- Pre-brew checklist
	- scale
	- need to order
	- have on-hand
		- use-first order
	- recipe specs
	- user notes
	- ingredient availability
	- needed containers
- brew-time checklist
	- scaled 
	- recipe
	- need to order
	- have on-hand
	- user notes 
	- available containers
- accurate inventory tracking 
	- final product
	- ingredients
- Indication to bartender which keg is on-deck. ==possible user story==
- determine how much final product is on hand, how much will be needed, how much to make.
- OLCC and ATF record automation
	- product in fermentor and bright tank
	- how many kegs in coolers
- controls for bar service:
	- update serving staff on current selection, on-deck.
	- maintain, adjust pars dynamically according to business, availability and inventory
---
### Inter-op Systems
- vendor DB
	- prices
	- available
- BeerSmith
- Current Website hosted by GoDaddy
	- includes "Storage"
	- currently shows whats on tap
		- needs to update on-tap, NOT on-deck (does not want customers to see what is next?) @website
---
### things to track
- prices
- on-hand / inventory
	-  on-trade to other breweries
	-  grains
	- hops
	- yeast
	- malts? ==is this a separate product?==
- upcoming needs
- recipes
	- ==BeerSmith== xml format
	  [[BeerXML]]
- container sizes available
- orders
	- date ordered
- loss/spillage
- Batch
	- final volume
		- Yields?
		- what containers / sizes they are racked into
	- During Brew Measurements
		- brew day, pre-ferment
			- OG, done boiling
			- PH, during boil?
			- mash Temp
			- Post mash Gravity
			- Specific Gravity during boil
			- pH before fermentor
		- post-ferment
			- pH
			- final Gravity
		- dry-hopped
			- date of dry hop
			- number of days
			- double dry-hop, bool
		- rack-date
			- 90 days = fresh
	- tasting notes
		- IBU - `how?`
		- color - `how?`
	- brewer notes
	
	#### for regulatory bodies
-	how much product is being brewed
-	how much product is on hand
	-	which state, and location
	-	in keg, is taxable, by OLCC
	-	barrels = 31 gal, ATF
	-	once a keg leaves the cooler, brewer is taxed.
-	spillage / loss
-	accidents 
---
### current system
- excel worksheets for inventory, recipes and ordering/prices
- beerSmith for 
	- recipe models 
	#### ordering
	- schedule out a month ahead
	- tally needs for month
	- order once a month
---
### User Types
- Admin
	- Owner
		- Everything
	- Partner
		- Everything?
- Brewery Employees
	- Brewer - 1 currently
	- assistant brewers
	- equipment cleaner
- Pub Employees
	- Manager
		- inventory
		- on-deck
	- Bar-Tender
		- inventory - input when changing kegs
		- on-deck - switched to DateTime
- Sales - 1 currently
	- see whats available
	- reserve beer for events
- Accountant
	- Inventory

#### Summary
Our client has a need for a single integrated system for tracking inventory across multiple locations and roles. We will design a software application that tracks and reports inventory, rotation, regulatory and tax related information, and variance in process, product and business trends.  

The different roles with access to the system will be Admin, Brewer, Pub Employee, Sales and accountant all with varying degrees of available data and permission to perform different functions depending on role.

Brews and ordering are planned out a month ahead of time, with ordering only actually taking place once a month. This system will aid in the process of ordering by keeping accurate inventory information in one place that is easily accessible to any role when they need it, as well as keeping this information synced and current across multiple locations and roles. 

---
### User Stories (Brewer Role)
1. 
As a Brewer I want to be able to,
	have all the data my accountant needs to do my taxes, aggregated in one place 
so that I can 
	ignore accounting details for the most part.
2. 
As a  Brewer I want to 
	have a checklist that I can go through prior to a brew
so that I can 
	be completely sure that all my "Mise en Place" (equipment, ingredients, containers) is ready without the need to check multiple locations, spreadsheets, or systems before a brew.
3. 
As a  Brewer I want to 
	be able to easily and quickly provide a regulating body, such as OLCC or ATF, with all the information they would be requiring during an audit  
so that I can 
	be legally compliant with regulations with little extra effort than my normal inventory functions.
4. 
As a  Brewer I want to 
	know all the available / clean / dirty equipment at a quick glance
so that I can 
	plan to clean / free up containers and other equipment ahead of a brew.
5.	 
As a  Brewer I want to 
	make sure to use older product before newer product and before ordering new product.
so that I can 
	minimize costs and maximize prophets while reducing waste.
