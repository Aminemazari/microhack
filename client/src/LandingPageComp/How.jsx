import React from 'react'
import a from '../assets/230.svg'
import {motion} from 'framer-motion';

const How = () => {
  return (
    <div className=''>
     <div className='flex-col ml-12 mt-32'>
      <p className='text-[#16DB65] text-[22px]'>Key Benefits</p>
      <h1 className='text-black text-4xl font-bold'>How it Works ?</h1>
      </div>
      <motion.div
      initial={{ y: '100%', opacity: 0 }} // Initial position and opacity
      animate={{ y: 30, opacity: 1 }} // Final position and opacity
      transition={{ duration: 1.5, ease: 'easeInOut' }} // Animation duration and easing
    >
      <div>
      <ul className='flex ml-6 justify-around mt-24'>
        <li>
            <ul className='flex-col justify-center '>
                <li ><img src={a} alt=""  className='mx-auto'/></li>
                <li>
                    <h3 className='text-black text-2xl text-left'>Project Creation and Assignment</h3>
                </li>
                <li> <p className='text-black text-[13px] mt-3 text-left'> Users create projects, inputting details like name,<br /> description, deadline, and team members, then assign them to <br /> specific companies.</p></li>
                </ul></li>
        <li> <ul>
                <li><img src={a} alt="" className='mx-auto' /></li>
                <li>
                    <h3 className='text-black  text-2xl text-center '>Task Decomposition and Assignment</h3>
                </li>
                <li> <p className='text-black text-[13px] mt-3 text-left '> Once a company accepts the project, it's broken down into smaller tasks, <br />aligned with project goals and required skills,<br /> then assigned to team members with set deadlines.</p></li>
                </ul></li>
        <li> <ul>
                <li><img src={a} alt="" className='mx-auto'/></li>
                <li>
                    <h3 className='text-black  text-2xl text-center' >Task Tracking and Reporting</h3>
                </li>
                <li> <p className='text-black text-[13px] mt-3 text-left' > Team members update task status <br /> (in progress, completed, brpending, etc.) <br /> in real-time, facilitating efficient project management.</p></li>
                </ul>
            </li>
      </ul></div>
    </motion.div>

    </div>
  )
}

export default How
