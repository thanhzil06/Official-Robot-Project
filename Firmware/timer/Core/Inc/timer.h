/*
 * timer.h
 *
 *  Created on: Sep 18, 2020
 *      Author: DELL
 */

#ifndef INC_TIMER_H_
#define INC_TIMER_H_

#include<stdint.h>
#include <stddef.h>
#define MAX_THREAD 10

typedef void (*thread_func_t)(char*);
typedef int thread_id_t;
typedef enum {
    THREAD_REPEAT,          // Function only run one time
    THREAD_SINGLESHOT       // Function run periodically
}thread_type_t;

typedef struct {
    thread_func_t thread_func;  // Pointer to function
    int period;                 // Period of function
    int count;                    // Internal counter
    thread_type_t type;         // Type of thread
    char* ctx;                  // Give this to function when run it
}thread_t;

thread_t m_thread[MAX_THREAD];

thread_id_t register_thread(thread_func_t thread_func, int period_ms, thread_type_t type, char* context);

uint8_t unregister_thread(thread_id_t proc_id);

void one_ms_timer_interrupt();

void blink_Led_2HZ(char *a);
void blink_Buzzer_halfHz(char *a);

#endif /* INC_TIMER_H_ */
