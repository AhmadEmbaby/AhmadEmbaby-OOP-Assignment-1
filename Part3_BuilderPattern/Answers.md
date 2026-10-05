====3.1


1. Why is a single 20 parameter constructor a problem??

a constructor with 20 parameters is hard to read and hard to use

there are alot of parameters and many of them have the same type like string or decimal so it is easy to put two values in the wrong order by mistake

it also becomes harder to maintain the code because if we add one more property we will need to change the constructor and every place that uses it

also when looking at the constructor call it is not always clear which value is for what






2. Is this only a long constructor problem??

no it isn't only because the constructor is long..... there is a bigger design problem because the invoice has many different types of information that are not really related to each other

for example billing and shipping are address information while payment and order information are something different

putting all of them in one big class makes the code harder to understand and mantain

it is better to separate the related information into smaller parts so each part has its own responsibility.

=====3.3

3. why is the composed version better than the single big builder??

the composed version is easier to understand because each builder has its own responsibility

the AddressBuilder is responsible for the address information and can validate that the address is complete.

the OrderBuilder is responsible for the order and payment information

the same AddressBuilder can be used for both billing and shipping so we dont need to write the same code twice

it also makes the code more readable because each part of the invoice is built separately

this makes the code easier to maintain and change later.