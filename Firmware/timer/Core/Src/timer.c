/*
 * timer.c
 *
 *  Created on: Sep 18, 2020
 *      Author: DELL
 */


#include "timer.h"
thread_id_t register_thread(thread_func_t thread_func, int period_ms, thread_type_t type, char* context) {
    for (int i = 0; i < MAX_THREAD; i++) {
        if (m_thread[i].thread_func == NULL) // Check if is there any empty slot
        {
            m_thread[i].thread_func = thread_func;
            m_thread[i].period = period_ms;
            m_thread[i].count = period_ms;
            m_thread[i].type = type;
            m_thread[i].ctx = context;
            return i;
        }
    }
    return -1; // if there is no slot remain, return invalid id
}
uint8_t unregister_thread(thread_id_t proc_id) {
    if (m_thread[proc_id].thread_func != NULL) {
        m_thread[proc_id].thread_func = NULL;
        return 1;
    }
    else {
        return 0;
    }
}
void one_ms_timer_interrupt() {
    for (int i = 0; i < MAX_THREAD; i++) {
        if (m_thread[i].thread_func != NULL) {
            m_thread[i].count--;                                  // Reduce internal counter
            if (m_thread[i].count == 0)                           // Check if timeout
            {
                m_thread[i].thread_func(m_thread[i].ctx);       // Run fucntion with context
                if (m_thread[i].type == THREAD_REPEAT)          // Check thread type
                {
                    m_thread[i].count = m_thread[i].period;       // Reset counter
                }
                else if (m_thread[i].type == THREAD_SINGLESHOT)
                {
                    m_thread[i].thread_func = NULL;             // Unregister thread
                }
            }
        }
    }
}


