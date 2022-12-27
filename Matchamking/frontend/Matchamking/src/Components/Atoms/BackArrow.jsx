import React from 'react'
import styled from 'styled-components'
import backarrow from '../../assets/bx-arrow-back.svg'
import BoxIconStyle from './BoxIconStyle'
import { useNavigate } from 'react-router-dom'


const StyledBackArrow = styled.div`
  position: absolute;
  left: 10%;
  top: 5%;
  font-size: 30px;
  width: 60px;
  height: 40px;
  color: white;
`

const BackArrow = ({navigate}) => {

  const navigation = useNavigate();
  return (
    <StyledBackArrow>
      <BoxIconStyle onClick={() => navigation(navigate)}>
        <img src={backarrow}></img>
      </BoxIconStyle>
    </StyledBackArrow>
  )
}

export default BackArrow