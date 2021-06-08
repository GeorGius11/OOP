
#include <iostream>
using namespace std;
#include <stdio.h>

#define STACK_SIZE 20
#define MAX 20
struct Node {
	int data;
	Node* next;

};
Node* top = NULL;

void push(int x)
{

	Node* newnode = new Node;
	newnode->data = x;
	newnode->next = top;
	top = newnode;

}


void pop()
{

	if (top == NULL)

		cout << "Stack Underflow" << endl;

	else
	{

		
		Node* c = top;
		top = top->next;
		delete c;

	}

}

void dfs(int Adj[][MAX], int n, int source);
int main(void) {
	//Adj matrix
	int Adj[][MAX] = { {0,1,0,1,0,0,0},{1,0,1,0,1,0,0},{0,1,0,0,0,1,0},{1,0,0,0,1,1,0},{0,1,0,1,0,1,1},{0,0,1,1,1,0,1},{0,0,0,0,1,1,0} };
	int n = 7; //no. of vertex
	int starting_vertex = 3;
	dfs(Adj, n, starting_vertex);
	system("pause");
	return 0;
}
void dfs(int Adj[][MAX], int n, int source) {
	//variables
	int i, j;
	bool change = false;
	//visited array to flag the vertex that
	//were visited
	int visited[MAX];
	//top of the stack
	                          
	//stack
	//int stack[STACK_SIZE];
	//set visited for all vertex to 0 (means unvisited)
	for (i = 0; i < MAX; i++) {
		visited[i] = 0;
	}

	//mark the visited source
	visited[source] = 1;
	//push the vertex into stack
	push(source);
	//print the vertex as result
	printf("%d ", top->data);
	//continue till stack is not empty

	while (top != NULL) {
		//to check if any vertex was marked as visited
		change = false;
		//get vertex at the top of the stack
		i = top->data;
		for (j = 0; j < n; j++) {
			if (visited[j] == 0 && Adj[i][j] == 1) {
				//mark vertex as visited
				visited[j] = 1;
				//push vertex into stack
				push(j);
				
				//print the vertex as result
				printf("%d ", j);
				//vertex visited
				change = true;
				break;
			}
		}
		if (change == false) {
			pop();
		}
	}
	printf("\n");
}
