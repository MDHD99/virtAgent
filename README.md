# assignment-decorators

### Answers//Mohamad Hammoud

## Exercise 1

Take a look at the code named ``PrintInf.py`` and answer the following questions:

1. What does the class ``PrintInf`` do?
```
__init__: gets  a function as its first argument to make it an attribute in the object

__call__: calls and prints that it is calling the called function
```
2. What is the decorator in this code?
```
The class "PrintInf"
```
3. What does this decorator do?
```
calls and prints that it called the function
```
4. How you tested this function? Provide the code.
```
class PrintInf:
    def __init__(self):
        self.enabled = True

    def __call__(self, f):
       
        def wrap(*args,**kwargs):
            if self.enabled:
                print('Calling {}'.format(f))
            return f(*args,**kwargs)
        return wrap

print_inf = PrintInf()

@print_inf
def rotate_list(l):
    return l[1:] + [l[0]]

list = [1,2,3,4]
print(rotate_list(list))

```

## Exercise 2

We want to create a decorator that counts the numbers of calls. To do so, follow the steps below:

1. Create a class named ``CallCount`` that have two methods: ``__init__`` and ``__call__``.
2. ``__init__`` take one argument and initializes the number of counts. ``__call__`` takes ``* args`` and ``** kwargs`` as input arguments. It increments the number of calls after each call.
3. Outside the class ``CallCount``, create a method called ``hello``, that takes on argument which is the name, and decorate it using ``CallCount``.
4. Test your code to check if the decorator is working as it should be.

## Answer:
```
class CallCount:
	def __init__(self):
		self.calls = 0

	def __call__(self, f):

		def wrap(*args,**kwargs):
			self.calls+=1
			print('{} has been called {} times'.format(f,self.calls))
			return f(*args,**kwargs)
		return wrap

call_count = CallCount()

@call_count
def hello(name):
	return name

hello_test = hello("Ali Komati")
hello_test2 = hello("Mohamad Hammoud")
print('{1} says hello to {0}'.format(hello_test,hello_test2))
```
