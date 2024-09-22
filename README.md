## UML 

![UML Class Messaging System](https://github.com/user-attachments/assets/7510d3f3-98d7-4e7d-90ac-45baf46c5d3f)

## Task
.Hobby animals need several things to preserve their exhilaration. Cathy has some hobby animals: fishes, birds, and dogs. Every animal has a name and their exhilaration level is between 0 and 100 (0 means that the animal dies).

• Fish: on a good day it’s exhilaration level increases by 1, on an ordinary day decreases by 3, and on a bad day decreases by 5.

• Bird: on a good day it’s exhilaration level increases by 3, on an ordinary day decreases by 1, and on a bad day decreases by 3.

• Dog: on a good day it’s exhilaration day increases by 5, on an ordinary day doesn’t change, and on a bad day decreases by 10.

• Good Day:If their keeper is in a good mood, she takes care of everything to cheer up her animals, and their exhilaration level increases: of the fishes by 1, of 
the birds by 2, and of the dogs by 3.

• Ordinary Day:On an ordinary day, Cathy takes care of only the dogs (their exhilaration level does not change), so the exhilaration level of the rest decreases: of the fishes by 3, of the birds by 1.
• Bad Day:On a bad day, every animal becomes a bit sadder and their exhilaration level decreases: of the fishes by 5, of the birds by 3, and of the dogs by 10.

Every data is stored in a text file. The first line contains the number of animals. Each of the following lines contain the data of one animal: one character for the type (F – Fish, B – Bird, D – Dog), name of the animal (one word), and the initial level of exhilaration.

In the last line, the daily moods of Cathy are enumerated by a list of characters (g – good, o – ordinary, b – bad). The file is assumed to be correct. Name the animal of the lowest level of exhilaration which is still alive at the end of the simulation. If there are more, name all of them!

## Analysis

Independent objects in the task are the animals. They can be divided into 3 different groups: Fishes, Birds and Dogs.
All of them have a name and a power that can be got. It can be examined what happens when they are being taken care of by the keeper. Day effects the animal in the following way:

<img width="360" alt="Screen Shot 2024-09-22 at 17 56 42" src="https://github.com/user-attachments/assets/fa13da99-d509-4522-a605-977a865f5fcf">

## Plan

To describe the animals, 4 classes are introduced: base class Animal to describe the general properties and 3 children for the concrete species: Fish, Bird, and Dog. Regardless the type of the creatures, they have several common properties, like the name (_name) and the exhilaration Level (_exhLevel), the getter of its name (name()), if it is alive (alive()) and it can be examined what happens when it was cared of. This latter operation (Traverse()) modifies the exhilaration level of the animal. Operations alive() and name() may be implemented in the base class already, but Traverse() just on the level of the concrete classes as its effect depends on the species of the creature. Therefore, the general class Creature is going to be abstract, as method Traverse() is abstract and we do not wish to instantiate such class.

To describe the keeper, a Keeper class is introduced. It has properties like the name (name) and animals (_animals), the getter for its animals(GetAnimals()), the inserter to it’s animals(TakeAnimal()), function to take care of the animal(CareAbout()), and function to simulate the Caring of its animals during given days (CareRoutine()), also the function to find the animal with the least exhilaration level, or few if the levels are the same.
General description of the days is done the base class Day from which concrete days are inherited: Good, Ordinal, and Bad. Every concrete ground has three methods that show how a Fish, a Bird, or a Dog changes during being taken care of.

The special animal classes initialize the name and the power through the constructor of the base class and override the operation Traverse() in a unique way. Initialization and the override are explained in Section Analysis. According to the tables, in method Traverse(), conditionals could be used in which the type of the day would be examined. Though, the conditionals would violate the SOLID principle of object-oriented programming and are not effective if the program might be extended by new day types, as all of the methods Traverse() in all of the concrete creature classes should be modified. To avoid it, the Visitor design pattern is applied where the day classes are going to have the role of the visitor.

Methods Traverse() of the concrete animals expect a day object as an input parameter as a visitor and call the methods which correspond to the species of the animals.

All the classes of the day are realized based on the Singleton design pattern, as it is enough to create one object for each class.

<img width="775" alt="Screen Shot 2024-09-22 at 18 00 25" src="https://github.com/user-attachments/assets/a013b1e3-fb92-4e61-b059-3e12312b626a">

Methods Traverse() of the concrete animals expect a day object as an input parameter as a visitor and call the methods which correspond to the species of the animals.
All the classes of the day are realized based on the Singleton design pattern, as it is enough to create one object for each class.

<img width="574" alt="Screen Shot 2024-09-22 at 18 00 59" src="https://github.com/user-attachments/assets/cfcb710c-5239-48dd-9fb3-a098de764678">

<img width="828" alt="Screen Shot 2024-09-22 at 18 03 03" src="https://github.com/user-attachments/assets/a210c627-53d3-49f1-964d-95afecfbf412">

If it is recognized that neither the creature, nor the grounds change after the death of the creature, the effectiveness of the above algorithm may be improved:

<img width="586" alt="Screen Shot 2024-09-22 at 18 03 43" src="https://github.com/user-attachments/assets/206781ac-1ab8-4b3f-be10-cbb0728e1b1f">


## Testing
### Grey box test cases:
#### Outer loop (Summation)
1. length-based:
- zero animal
- one animal
- more animals
2. first and last:
- first animal survives or not the care
- last animal survives or not the care
#### Inner loop (Summation)
1. length-based:
- one animal on a zero-long days
- one animal on a one-long days traverses properly
- one animal on a longer days (survives or dies)
Examination of function traverse()
Nine different cases depending on the Animal and the Day




