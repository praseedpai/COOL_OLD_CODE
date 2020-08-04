#include <stdio.h>
#include <stdlib.h>

int main( int argc , char **argv ) {
   const double EPSILON = 0.000000001;
   if ( argc != 2 ) {
      printf("Wrong Command line arguments\n"); return -1;
   }
   double s = atof(argv[1]),guess;
   guess = s/2.0;

   while ( abs(guess*guess - s ) >= EPSILON )
	guess = guess - ((guess*guess) -s ) / (guess*2);
  
   printf("SQUARE root is %g\t%g\n", guess,guess*guess );

   return 0;
}