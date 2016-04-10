﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeGen;

namespace Pchp.CodeAnalysis.Symbols
{
    class SynthesizedMethodSymbol : MethodSymbol
    {
        readonly TypeSymbol _type;
        readonly bool _static;
        readonly string _name;
        protected ImmutableArray<ParameterSymbol> _parameters;
        TypeSymbol _return;

        public SynthesizedMethodSymbol(TypeSymbol containingType, string name, bool isstatic, TypeSymbol returnType, params ParameterSymbol[] ps)
        {
            _type = containingType;
            _name = name;
            _static = isstatic;
            _return = returnType;
            _parameters = ps.AsImmutable();
        }

        public override Symbol ContainingSymbol => _type;

        internal override IModuleSymbol ContainingModule => _type.ContainingModule;

        public override Accessibility DeclaredAccessibility => Accessibility.Private;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsAbstract => false;

        public override bool IsExtern => false;

        public override bool IsOverride => false;

        public override bool IsSealed => !IsStatic;

        public override bool IsStatic => _static;

        public override bool IsVirtual => false;

        public override ImmutableArray<Location> Locations
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MethodKind MethodKind => MethodKind.Ordinary;

        public override string Name => _name;

        public override ImmutableArray<ParameterSymbol> Parameters => _parameters;
        
        public override bool ReturnsVoid => _return.SpecialType == SpecialType.System_Void;

        public override TypeSymbol ReturnType => _return;

        internal override ObsoleteAttributeData ObsoleteAttributeData => null;

        internal override bool IsMetadataNewSlot(bool ignoreInterfaceImplementationChanges = false) => false;

        internal override bool IsMetadataVirtual(bool ignoreInterfaceImplementationChanges = false) => IsVirtual;
    }
}