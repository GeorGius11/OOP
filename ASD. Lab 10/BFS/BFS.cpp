#include <stdio.h>
#include <iostream>
using namespace std;

#define QUEUE_SIZE 20
#define MAX 20
//queue

struct Queue
{
	int age;
	Queue* next;
	Queue* prev;
};

Queue* first = NULL;
Queue* last = NULL;

//Creation of the first element of the queue
void InitQueue(int x)
{
	first = new Queue;
	
	
	first->age = x;
	first->next = NULL;
	first->prev = NULL;
	last = first;
}

//Add new element at the end of the queue
void InQueue(int x)
{
	if (first == NULL && last == NULL)
	{
		first = new Queue;


		first->age = x;
		first->next = NULL;
		first->prev = NULL;
		last = first;
	}
	else
	{
		Queue* c = new Queue;

		if (last == first)
		{
			c->age = x;
			c->next = last;

			last = c;
			first->prev = last;
		}
		else
		{
			c->age = x;
			c->next = last;
			last->prev = c;
			last = c;
		}
	}
}

// Remov element from the beginning of the queue
void OutQueue()
{
	/*if (first == NULL) { cout << "The queue is empty" << endl; return -1; }*/
	if (first == last)
	{
		Queue* c = first;
		
		delete c;
		first = NULL; last = NULL;
		
	}
	else
	{
		Queue* c = first;
		/*first->age++;*/
		first = first->prev;
		delete c;
	}
	
}

//int queue[QUEUE_SIZE];
//int queue_front, queue_end;
//void enqueue(int v);
//int dequeue();
void bfs(int Adj[][MAX], int n, int source);
int main(void) {
	//Adj matrix
	int Adj[][MAX] = { 
		{0,1,1,0,0,0,0},
		{1,0,0,1,1,0,0},
		{1,0,0,1,0,1,0},
		{0,1,1,0,1,1,1},
		{0,1,0,1,0,0,1},
		{0,0,1,1,0,0,1},
		{0,0,0,1,1,1,0}};
	int n = 7; //no. of vertex
	int starting_vertex = 0;
	bfs(Adj, n, starting_vertex);
	system("pause");
	return 0;
}
void bfs(int Adj[][MAX], int n, int source) {
	//variables
	int i, j;
	//visited array to flag the vertex that
	//were visited
	int visited[MAX];
	//queue
	/*queue_front = 0;
	queue_end = 0;*/
	//set visited for all vertex to 0 (means unvisited)
	for (i = 0; i < MAX; i++) {
		visited[i] = 0;
	}
	//mark the visited source
	visited[source] = 1;
	//enqueue visited vertex
	
	InQueue(source);
	
	//print the vertex as result
	printf("%d ", first->age);
	//continue till queue is not empty
	while (true) 
	{
		if (first != NULL && last != NULL)
		{
			if (first->age <= last->age)
			{
				//dequeue first element from the queue
				i = first->age;
				OutQueue();
				

				for (j = 0; j < n; j++) {
					if (visited[j] == 0 && Adj[i][j] == 1) {
						//mark vertex as visited
						visited[j] = 1;
						//push vertex into stack
						InQueue(j);
						//print the vertex as result
						printf("%d ", j);
					}
				}
			}
			else OutQueue();
		}
		else break;
	}
	printf("\n");
}
