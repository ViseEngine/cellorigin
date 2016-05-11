﻿using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Framework
{
    class ViewTemplate
    {
        public static string ClassName( DataContext ctx )
        {
            return ctx.Name + "View";
        }

        public static string ClassItemName(DataContext ctx)
        {
            return ctx.ItemName + "View";
        }
       
        public static string WidgetVariable(DataContext ctx)
        {
            return "_" + ctx.Name;
        }

        public static string WidgetTypeName(DataContext ctx )
        {           
            switch( ctx.Type )
            {
                case WidgetType.ScrollRect:
                    return "Framework.ListControl";
                default:
                    return ctx.Type.ToString();
            }
        }

        public static string WidgetData(DataContext ctx)
        {
            switch (ctx.Type)
            {
                case WidgetType.Text:
                case WidgetType.InputField:
                    {
                        return WidgetVariable(ctx) + ".text";
                    }
            }

            // TODO 处理错误

            return "Unknown";
        }


        public static void ClassBody( CodeGenerator gen, DataContext rootContext, List<DataContext> widgetContextList )
        {            
            gen.PrintLine("// Generated by github.com/davyxu/cellorigin");
            gen.PrintLine("using UnityEngine;");
            gen.PrintLine("using UnityEngine.UI;");
            gen.PrintLine();

            gen.PrintLine("partial class ", ClassName(rootContext), " : Framework.BaseView");
            gen.PrintLine("{");
            gen.In();

            gen.PrintLine(PresenterTemplate.ClassName(rootContext), " _Presenter;");
            gen.PrintLine();
            // TODO 变量声明代码

            foreach( DataContext widgetContext in widgetContextList)
            {
                WidgetDeclare(gen, widgetContext);
            }

            gen.PrintLine();


            gen.PrintLine("public override void Bind( Framework.BasePresenter presenter )");
            gen.PrintLine("{");
            gen.In();

            gen.PrintLine("_Presenter = presenter as ", PresenterTemplate.ClassName(rootContext), ";");
            gen.PrintLine();

            gen.PrintLine("var trans = this.transform;");
            gen.PrintLine();

            // TODO List中的名称重名检查
            
            // 打印控件搜索代码
            foreach (DataContext widgetContext in widgetContextList)
            {
                FindWidgetlAssignToVar(gen, rootContext, widgetContext);
            }

            gen.PrintLine();

            // 打印控件绑定代码
            foreach (DataContext widgetContext in widgetContextList)
            {
                WidgetBind(gen, rootContext, widgetContext);
            }

            


            gen.Out();
            gen.PrintLine("}"); // Bind
            gen.PrintLine();

            gen.Out();
            gen.PrintLine("}"); // Class
        }



        public static void FindWidgetlAssignToVar(CodeGenerator gen, DataContext rootContext, DataContext widgetContext)
        {
            var path = ObjectUtility.GetGameObjectPath(widgetContext.gameObject, rootContext.gameObject);

            gen.PrintLine(WidgetVariable(widgetContext), " = trans.Find(\"", path, "\").GetComponent<", WidgetTypeName(widgetContext), ">();");
        }

        // 一个View变量的声明代码
        public static void WidgetDeclare(CodeGenerator gen, DataContext widgetContext)
        {
            gen.PrintLine(WidgetTypeName(widgetContext), " ", WidgetVariable(widgetContext), ";");
        }

        // 一个View变量的绑定代码
        public static void WidgetBind(CodeGenerator gen, DataContext rootContext, DataContext widgetContext)
        {
            switch (widgetContext.Type)
            {
                case WidgetType.ScrollRect:
                    {
                        gen.PrintLine("Framework.Utility.BindCollection<int, ",
                                    PresenterTemplate.ClassItemName(widgetContext), ", ",
                                    ClassItemName(widgetContext), ">( _Presenter.", PresenterTemplate.Property(widgetContext),
                                    ", ", WidgetVariable(widgetContext), " );"
                                );
                        gen.PrintLine();
                    }
                    break;
                case WidgetType.Button:
                    {
                        gen.PrintLine(WidgetVariable(widgetContext), ".onClick.AddListener( _Presenter.", PresenterTemplate.Command( widgetContext ), " );" );
                    }
                    break;
                case WidgetType.InputField:
                case WidgetType.Text:
                    {
                        if (widgetContext.SyncType == DataSyncType.ViewToPresenter || widgetContext.SyncType == DataSyncType.TwoWay)
                        {
                            gen.PrintLine(WidgetVariable(widgetContext), ".onValueChanged.AddListener( x =>");
                            gen.PrintLine("{");
                            gen.In();
                            gen.PrintLine("_Presenter.", PresenterTemplate.Property(widgetContext), " = x;");
                            gen.Out();
                            gen.PrintLine("} );");

                            // 初始赋值
                            gen.PrintLine("_Presenter.", PresenterTemplate.Property(widgetContext), " = ", WidgetData(widgetContext), ";");
                        }

                        if (widgetContext.SyncType == DataSyncType.PresenterToView || widgetContext.SyncType == DataSyncType.TwoWay)
                        {
                            gen.PrintLine("_Presenter.", PresenterTemplate.Event(widgetContext), " += delegate()");
                            gen.PrintLine("{");
                            gen.In();

                            switch (widgetContext.Type)
                            {
                                case WidgetType.Text:
                                case WidgetType.InputField:
                                    {
                                        gen.PrintLine(WidgetVariable(widgetContext), ".text = _Presenter.", PresenterTemplate.Property(widgetContext), ";");
                                    }
                                    break;
                            }

                            gen.Out();
                            gen.PrintLine("};");

                            gen.PrintLine("if ( _Presenter.", PresenterTemplate.Property(widgetContext), " != null )");
                            gen.PrintLine("{");
                            gen.In();
                            // 初始赋值
                            gen.PrintLine(WidgetData(widgetContext), " = ", "_Presenter.", PresenterTemplate.Property(widgetContext), ";");
                            gen.Out();
                            gen.PrintLine("}");
                        }

                        gen.PrintLine();
                    }
                    break;
            }



            
 
        }

        public static string FullFileName( DataContext ctx )
        {
            return string.Format("Assets/Script/View/{0}/{1}.codegen.cs", ctx.Name, ClassName(ctx));
        }

        public static void Delete( DataContext rootContext )
        {
            var file = FullFileName(rootContext);
            if ( File.Exists(file))
            {
                File.Delete(file);
            }
            
        }

        public static void Save( CodeGenerator gen, DataContext rootContext )
        {            
            CodeUtility.WriteFile(FullFileName( rootContext ), gen.ToString());
        }

        
       
    }
}
