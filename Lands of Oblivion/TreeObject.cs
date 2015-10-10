using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class TreeObject{
    private Boolean leftChildSet = false;
    private Boolean rightChildSet = false;
    private readonly int x;
    private readonly int y;
    private readonly int width;
    private readonly int length;
    private TreeObject leftChild;
    private TreeObject rightChild;
    
    public TreeObject(int x, int y, int width, int length){
        this.x = x;
        this.y = y;
        this.width = width;
        this.length = length;
    }

    public Boolean setLeftChild(TreeObject leftChild) {
        Boolean returned;
        if (!leftChildSet) {
            this.leftChild = leftChild;
            this.leftChildSet = true;
            returned = true;
        } else {
            returned = false;
        }
        return returned;
    }

    public Boolean setRightChild(TreeObject rightChild) {
        Boolean returned;
        if (!rightChildSet) {
            this.rightChild = rightChild;
            this.rightChildSet = true;
            returned = true;
        }
        else {
            returned = false;
        }
        return returned;
    }


    public Boolean contains(int x, int y){
        Boolean returned;
        Boolean xFits = false;
        Boolean yFits = false;


        if (x >= this.x && x < this.x + this.width) {
            xFits = true;
        }
        if (y >= this.y && y < this.y + this.length) {
            yFits = true;
        }

        if (xFits && yFits) {
            returned = true;
        } else {
            returned = false;
        }

        return returned;
    }
}
