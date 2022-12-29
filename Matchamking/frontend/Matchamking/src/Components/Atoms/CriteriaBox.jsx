import React from 'react'
import styled from 'styled-components'
import StyledBox from './BoxStyle'

const Box = styled(StyledBox)`
    display: flex;
    height: 25px;
    font-size: 16px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
    width: 100%;
`


const CriteriaBox = () => {
  return (
    <Box>
        Hola
    </Box>
  )
}

export default CriteriaBox