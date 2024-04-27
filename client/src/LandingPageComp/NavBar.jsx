import React from 'react'
import Vector from '../assets/Vector.svg'

const NavBar = () => {
  return (
    <div className='py-[12px] px-[24px] bg-[#16DB65]'>
      <ul className='flex justify-between  items-center'>
        <li className='w-[15%]'>
          <img src={Vector} alt="" />
        </li>
        <li>
          <div>
            <ul className='flex gap-16  items-center '>
              <li className='text-[#181D18] text-[18px] font-semibold'>Work</li>
              <li className='text-[#181D18] text-[18px] font-semibold'>Services</li>
              <li className='text-[#181D18] text-[18px] font-semibold'>Company</li>
            </ul>
          </div>
        </li>
        <li>
          <div>
            <ul className='flex gap-12 items-center'>
              <li><button className='text-[#181D18] text-[18px] font-semibold '>Log In</button></li>
              <li><button className='text-white py-[10px] px-[16px] bg-[#181D18] rounded-3xl text-[18px] font-semibold'>SignUp</button></li>
            </ul>
          </div>
        </li>
      </ul>
    </div>
  )
}

export default NavBar
