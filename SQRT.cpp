#include <stdio.h>
#include <stdlib.h>

int main( int argc , char **argv ) {
   const double EPSILON = 0.000000001;
   if ( argc != 2 ) {
      printf("Wrong Command line arguments\n"); return -1;
   }
   double s = atof(argv[1]),i=1,j=0;
   while (i*i <= s ) { j= i++; }
   if ( abs(j*j-s) <= EPSILON ) {
        printf("  Square Root of numbers = %e\t%g\n",j,j*j); return 0;
   }
   double left = 0.0,right = 0.9999999,new_root=0.0;
   int index=0;
   while (1) {
      new_root = j + (( left + right )*0.5);
      double diff = new_root * new_root - s ;
      if (  abs(diff) <= EPSILON || ( index++ >=1000 ) ) {  break;}
      if ( (diff >= 0 ) ) { right =  mid; } else { left =  mid; }
    }
    printf(" In %d Iterations : Square Root of numbers = %e\t%g\n",index,new_root ,new_root *new_root );
    return 0;
}