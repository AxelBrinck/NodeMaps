# NodeMaps
_Engage the next level database speed, designing your custom index_

## Introduction
Every data set needs an index to unlock fast access time to an specific
entry.

NodeMaps gives you the tools you need to design the fastest index scheme
for your data.

When you know how your queries should exactly travel through your data.
It is time to switch to the fastest query mechanism, NodeMaps.

## What is NodeMaps?
NodeMaps is a **framework** to interact with an node-indexed data file.

## How it works?
NodeMaps will treat every data field as a node.  
Being a node, you can directly link to other nodes gaining direct reference
from the actual data, without traveling several automatically created external indexes.

This way, you not only design your database structure, at the same time
you design its index connectivity for optimal seek route.

## How it is compared to other dbs?
NodeMaps cannot be used as your primary database, as it is just a **file format**. Means that it lacks server functionality.

It must be used **alongside** your primary database to enable **light speed** to certain queries.

## Best use case?
Ideally, this database is intended for **huge time based data sets**. Like stock market data.

_If your data size is small, it is better to go for a memory based db like redis._

What was the temperature in ten different cities yesterday at 6 o'clock?  

In a common database you will have to get the last entry for every city at six o'clock.

But with NodeMaps you can design a tree index that goes all the way down from years to minutes, and entries are separated in tracks for each city, being them placed between the hours. So getting the last temperature in a given time becomes a blazing FAST task.

## How can I use it?
Simply clone and link this class library to your project.
