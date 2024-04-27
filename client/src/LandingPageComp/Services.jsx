import React from 'react'

const Services = () => {
  return (
    <div className=' py-[10rem] bg-white mt-8 text-'>
        <h1 className='ml-12 text-4xl text-black font-bold'>Services</h1>
        <div className='mt-12 bg-white'>
    <div className='max-w-[1240px] mx-auto grid md:grid-cols-3 gap-8  '>
        <div className='w-full shadow-xl rounded-md p-4 my-4 flex flex-col hover:scale-105 duration-300 bg-white'>
           
            <h2 className='text-2xl font-bold text-center py-8  text-[#181D18]'> Small Business</h2>
            <p className='text-center py-4 text-4xl font-bold mb-2 text-[#181D18]'>$29.99</p>
            <div className='text-center text-[20px] '>
            <p className='py-2 text-[#181D18]'>Manage 100 tasks easily</p>
            <p className='py-2  text-[#181D18]'>Efficient communication tools</p>
            <p className='py-2  text-[#181D18]'>Simple and affordable</p> 
            </div>
            <button className='mt-4 bg-white text-[#16DB65]  font-bold w-[40%] mx-auto rounded-md p-2'>Start Trial</button>
        </div>

        <div className='w-full shadow-xl rounded-md p-4  flex flex-col hover:scale-105 duration-300 bg-[#16DB65] md:my-0 my-8'>
          
            <h2 className='text-2xl font-bold text-center py-8 text-[#181D18]'>Medium Business</h2>
            <p className='text-center py-4 text-4xl font-bold mb-2  text-[#181D18]'>$59.99</p>
            <div className='text-center text-[20px] '>
            <p className='py-2  text-[#181D18]'>Up to 500 tasks</p>
            <p className='py-2  text-[#181D18]'> Advanced task management</p>
            <p className='py-2  text-[#181D18]'>Real-time updates</p> 
            </div>
            <button className='mt-4 bg-white text-[#16DB65] font-bold w-[40%] mx-auto rounded-md p-2'>Start Trial</button>
        </div>


        <div className='w-full shadow-xl rounded-md p-4  flex flex-col bg-white hover:scale-105 duration-300 my-8'>
            <h2 className='text-2xl font-bold text-center py-8  text-[#181D18]'>Enterprise Solution</h2>
            <p className='text-center py-4 text-4xl font-bold mb-2  text-[#181D18]'>$99.99</p>
            <div className='text-center text-[20px] '>
            <p className='py-2  text-[#181D18]'>Unlimited task management</p>
            <p className='py-2  text-[#181D18] '> Premium support and features</p>
            <p className='py-2  text-[#181D18]'> Customized for enterprises</p> 
            </div>
            <button className='mt-4 bg-white text-[#16DB65]  font-bold w-[40%] mx-auto rounded-md p-2'>Start Trial</button>
        </div>
        
       
    </div>
  
</div></div>
  )
}

export default Services
