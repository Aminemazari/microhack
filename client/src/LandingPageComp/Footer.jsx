import React from 'react'
import Logo from '../assets/Layer 1.svg'

const Footer = () => {
  return (
    <div className='flex justify-around items-center pb-6 pt-4 '>
      <div >
      <img src= {Logo} alt="" />
      </div>
      <div className=' flex flex-col-3 gap-10'>
        <ul>
            <li className='text-[#181D18] mt-2 font-bold'>Contact Us </li>
             <li className='text-[#181D18] mt-2'>Phone:+1 (123) 456-7890</li>
             <li className='text-[#181D18] mt-2'>Email:contact@optifield.com</li>
        </ul>
        <ul>
            <li className='text-[#181D18] mt-2 font-bold' >Explore </li>
            <li className='text-[#181D18] mt-2'>About Us</li>
            <li className='text-[#181D18] mt-2'> FAQ  </li>
            <li className='text-[#181D18] mt-2'>Blog</li>
            <li className='text-[#181D18] mt-2'>Testimonials</li>
        </ul>
        <ul>
            <li className='text-[#181D18] mt-2 font-bold'>Follow Us</li>
            <li className='text-[#181D18] mt-2'>LinkedIn </li>
            <li className='text-[#181D18] mt-2'>Instagram</li>
            <li className='text-[#181D18] mt-2'>Facebook </li>
        </ul>

      </div>
    </div>
  )
}

export default Footer
