#include <stdio.h>
#include <stdlib.h>

int main( int argc , char **argv ) {
    
   if ( argc != 2 ) {
      printf("Wrong Command line arguments\n");
      return -1;
   }

   double s = atof(argv[1]);

   double i,j;
   i=1;
   j=0;
   while (1) {

         if ( i*i > s ) {
              break;
         }
         j= i;
         i++;
   }

   printf("Perfect Square within numbers = %e\n",j);
   return 0;

}