import React from 'react'
import Arrow from '../assets/Arrow_01.svg'
import dashboard from '../assets/Dashboard 1.svg'
import { motion } from 'framer-motion'
const Hero = () => {
  return (
    <div className='bg-[#16DB65] mb-16 relative min-h-screen '>
<div class=" text-center"><span className="text-black text-[64px] font-bold font- capitalize leading-[96px] tracking-wide">Your path to </span><span className="text-white text-[64px] font-bold  capitalize leading-[96px] tracking-wide">on-site</span><span className="text-black text-[64px] font-bold  capitalize leading-[96px] tracking-wide"> success</span></div>     

<div class=" text-center text-stone-900 text-[22px] font-normal  leading-[33px]">OptiField: The All-in-One Platform for Streamlined Field Task <br /> Management.</div>
      <img src={Arrow} alt=""  className='ml-[30%] mt-[-3%] absolute'/>
      <div class=" px-5 py-3.5 bg-stone-900 rounded-[100px] shadow justify-center items-center inline-flex ml-[43.5%] mt-[3%] relative">
    <div class="px-3 justify-center items-center flex">
        <div class="text-center text-neutral-50 text-md font-medium  leading-tight tracking-tight">Start Your Free Trial</div>
    </div>
  
</div>
<motion.div
      initial={{ translateY: 120, opacity: 0 }} 
      animate={{ translateY: 10, opacity: 1 }}
      transition={{ duration: 1, ease: 'easeIn' }} 
    >

      <img src={dashboard}  alt="" className='ml-[10%] mb-12 absolute'/>
    </motion.div >

    </div>
  )
}

export default Hero
